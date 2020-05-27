using System.Collections;
using CustomSystem.Audio;
using UnityEngine.UI;
using CustomSystem;
using UnityEngine;
using System;
using Prefab;
using TMPro;

namespace Characters
{
    public class CharacterController : LegacyInputImplementation
    {
        [Header("Configuration")] public int id;
        public CharacterStatus characterStatus;

        public float currentHealth;

        private float _scenarioDamageMultiply = 1;
        private float _shootDamageMultiply = 1;
        private float _takeDamageMultiply = 1;
        private float _knockBackMultiply = 1;

        [Header("References")] [SerializeField]
        private Transform groundCheckPosition;

        [SerializeField] private Image hpBar;
        [SerializeField] private Image coolDownBar;

        [SerializeField] private LayerMask ground;
        [SerializeField] protected GameObject projectile;
        [SerializeField] protected GameObject weapon;
        [SerializeField] private GameObject dashEffect;
        [SerializeField] private Transform spawnProjectilePosition;
        [SerializeField] public GameObject playerCanvas;
        [SerializeField] public GameObject shield;
        [SerializeField] public TextMeshProUGUI indicatorTxt;
        [SerializeField] public GameObject deathEffect;

        [Header("Control")] [SerializeField] private bool canDoubleJump = true;
        [SerializeField] private bool isOnGround;
        [SerializeField] private bool lookingLeft;

        private Rigidbody2D _playerRb;
        [SerializeField] private float groundCheckRadius;
        private Vector2 _direction;

        private float _auxMoveSpeed;
        private bool _canMove = true;
        [SerializeField] private bool canDash = true;
        [SerializeField] private bool isDashing;
        private bool _aiming;
        private bool _canUseSkill;
        private float _auxCoolDownSkill;
        protected Vector2 playerDirection;
        private float _defaultGravity;
        private bool _canMidAir = true;
        [SerializeField] private bool isMidAir;
        [SerializeField] private bool canShoot = true;
        [SerializeField] private float auxMidAirDuration;
        private PowerUpHandler _powerUpHandler;
        [HideInInspector] public AudioHolder audioHolder;
        public int whoControlMe;
        private float _auxFireRate;
        private JoystickIndex _joystickIndex;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody2D>();
            _powerUpHandler = GetComponent<PowerUpHandler>();
            playerCanvas.transform.SetParent(null);
            StartCoroutine(SetCharacterImmune());
        }

        private void Start()
        {
            _auxFireRate = characterStatus.fireRate;
            audioHolder = GetComponent<AudioHolder>();
            auxMidAirDuration = characterStatus.midAirDuration;
            currentHealth = characterStatus.maxHealth;
            _auxMoveSpeed = characterStatus.moveSpeed;
            _defaultGravity = _playerRb.gravityScale;
            CheckJoystick();

            indicatorTxt.SetText("P" + (whoControlMe + 1));

            CustomStart();
        }

        private void CheckJoystick()
        {
            if (whoControlMe == 0)
            {
                _joystickIndex = JoystickIndex.JoystickOne;
                SetJoystick(JoystickIndex.JoystickOne);
            }

            else if (whoControlMe == 1)
            {
                _joystickIndex = JoystickIndex.JoystickTwo;
                SetJoystick(JoystickIndex.JoystickTwo);
            }

            else if (whoControlMe == 2)
            {
                _joystickIndex = JoystickIndex.JoystickThree;
                SetJoystick(JoystickIndex.JoystickThree);
            }
            else
            {
                _joystickIndex = JoystickIndex.JoystickFour;
                SetJoystick(JoystickIndex.JoystickFour);
            }
        }

        private IEnumerator SetCharacterImmune()
        {
            var temp = Instantiate(shield, transform.position, Quaternion.identity);
            temp.transform.SetParent(transform);
            SetPlayerTag("Untagged");
            yield return new WaitForSeconds(2.5f);
            SetPlayerTag("Player");
            Destroy(temp);
        }
        
        private void SetPlayerTag(string playerTag)
        {
            transform.tag = playerTag;
        }

        protected virtual void CustomStart()
        {
        }
        private void Update()
        {
            if (!GameController.instance.gameRunning) return;
            if (GameController.instance.gamePaused) return;
            if (ButtonStart())
            {
                GameController.instance.PauseGame(_joystickIndex);
            }
            
            playerDirection = ButtonDirection();
            if (_canMove)
            {
                Move(playerDirection.x);
            }

            if (ButtonA())
            {
                CheckForJump();
            }

            if (ButtonA(ButtonState.ButtonUp))
            {
                CancelJump();
            }

            if (ButtonRb(true))
            {
                LockToAim();
            }
            else if (ButtonLb(true))
            {
                CheckMidAirStatus();
            }
            else
            {
                PlayerNotAiming();
            }

            if (ButtonX() && canShoot)
            {
                CheckShootDirection(playerDirection);
            }

            if (ButtonY() && canDash)
            {
                SoundManager.instance.PlayAudio(audioHolder.dash);
                Dash(playerDirection);
            }

            if (ButtonB() && _canUseSkill)
            {
                EspecialSkill();
            }

            CheckGroundCollision();
            CheckPlayerDirection(playerDirection.x);
            CustomUpdate();
            CoolDownStatus();
            MakeIndividualHudFollowPlayer();
            FireRateCalculate();
        }

        private void MakeIndividualHudFollowPlayer()
        {
            var position = transform.position;
            playerCanvas.transform.position = new Vector2(position.x, position.y + 0.1f);
        }

        private void FireRateCalculate()
        {
            if (!canShoot)
            {
                _auxFireRate -= Time.deltaTime;
                if (_auxFireRate <= 0)
                {
                    canShoot = true;
                    _auxFireRate = characterStatus.fireRate;
                }
            }
        }

        private void LockToAim()
        {
            if (isOnGround)
            {
                Aim();
                _playerRb.velocity = Vector2.zero;
            }
        }

        private void CheckMidAirStatus()
        {
            Aim();
            if (_canMidAir && !isOnGround)
            {
                auxMidAirDuration = characterStatus.midAirDuration;
                _canMidAir = false;
                isMidAir = true;
            }

            if (isMidAir)
            {
                MidAirEffect();
                auxMidAirDuration -= Time.deltaTime;
                if (auxMidAirDuration <= 0)
                {
                    isMidAir = false;
                }
            }
        }

        private void CoolDownStatus()
        {
            if (_auxCoolDownSkill < characterStatus.coolDownSkill)
            {
                _auxCoolDownSkill += Time.deltaTime;
                coolDownBar.fillAmount = (_auxCoolDownSkill * 1f / characterStatus.coolDownSkill);
            }
            else if (_auxCoolDownSkill >= characterStatus.coolDownSkill && !_canUseSkill)
            {
                _canUseSkill = true;
                coolDownBar.color = Color.green;
            }
        }

        protected virtual void ResetCoolDown()
        {
            _canUseSkill = false;
            _auxCoolDownSkill = 0;
            coolDownBar.color = Color.white;
        }

        protected virtual void CustomUpdate()
        {
        }

        protected virtual void EspecialSkill()
        {
            coolDownBar.fillAmount = 0;
        }

        private void CheckShootDirection(Vector2 shootDirection)
        {
            SoundManager.instance.PlayAudio(audioHolder.shoot);
            canShoot = false;
            Shoot(_aiming ? shootDirection : Vector2.zero, projectile);
        }

        private void CheckForJump()
        {
            if (isOnGround)
            {
                JumpEffect(0.8f * transform.localScale.x, 1.5f);
                Jump(characterStatus.jumpForce);
            }
            else
            {
                if (!ButtonA()) return;
                if (!canDoubleJump) return;
                Jump(characterStatus.doubleJumpForce);
                canDoubleJump = false;
            }
        }

        private void PlayerNotAiming()
        {
            if (canDash)
            {
                _playerRb.gravityScale = _defaultGravity;
            }
        
            _aiming = false;
            characterStatus.moveSpeed = _auxMoveSpeed;
            RotateWeapon(new Vector2(180, 0));
        }

        private void MidAirEffect()
        {
            var currentSpeed = _playerRb.velocity;
            currentSpeed.x /= 2;
            currentSpeed.y /= 2;
            _playerRb.velocity = currentSpeed;
            _playerRb.gravityScale = 2f;
        }

        private void Aim()
        {
            _aiming = true;
            characterStatus.moveSpeed = _auxMoveSpeed / 5;
            var v = playerDirection;
            if (lookingLeft)
            {
                if (Math.Abs(v.x) > 0 || Math.Abs(v.y) > 0)
                {
                    RotateWeapon(new Vector2(v.x * -1, v.y));
                }
                else
                {
                    RotateWeapon(new Vector2(180, -1));
                }
            }
            else
            {
                RotateWeapon(new Vector2(v.x, v.y * -1));
            }
        }

        private void CheckPlayerDirection(float direct)
        {
            if (direct > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                lookingLeft = false;
            }
            else if (direct < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                lookingLeft = true;
            }
        }

        private void RotateWeapon(Vector2 direct)
        {
            var angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            weapon.transform.rotation = Quaternion.Slerp(
                weapon.transform.rotation, rotation, characterStatus.weaponRotateSpeed * Time.deltaTime
            );
        }


        private void CheckGroundCollision()
        {
            isOnGround = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, ground);
            if (isOnGround)
            {
                canDoubleJump = true;
            }
        }

        private void Move(float directionX)
        {
            _playerRb.velocity = new Vector2(
                directionX * characterStatus.moveSpeed * Time.deltaTime, _playerRb.velocity.y
            );
        }

        private void Jump(float force)
        {
            SoundManager.instance.PlayAudio(audioHolder.jumpEffect);
            var tempTransform = transform;
            var position = tempTransform.position;
            position.y += 0.5f;
            tempTransform.position = position;
            var jumpVector = new Vector2(_playerRb.velocity.x, force * Time.deltaTime);
            _playerRb.velocity = jumpVector;
        }

        private void CancelJump()
        {
            if (_playerRb.velocity.y > 0)
            {
                var velocity = _playerRb.velocity;
                velocity.y *= 0.25f;
                _playerRb.velocity = velocity;
            }
        }

        private void Dash(Vector2 dashDirection)
        {
            _playerRb.gravityScale = 0;
            _canMove = false;
            canDash = false;
            isDashing = true;
            StartCoroutine(DashEffect());
            var velocity = new Vector2(characterStatus.dashForce * Time.deltaTime * dashDirection.x,
                characterStatus.dashForce * Time.deltaTime * dashDirection.y * -1);
            _playerRb.velocity = velocity;
            StartCoroutine(DashDurationDelay(characterStatus.dashDuration));
            StartCoroutine(DashCoolDown(characterStatus.dashCoolDown));
        }

        private IEnumerator DashDurationDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _playerRb.gravityScale = _defaultGravity;
            _canMove = true;
            isDashing = false;
        }

        private IEnumerator DashCoolDown(float coolDown)
        {
            yield return new WaitForSeconds(coolDown);
            canDash = true;
        }

        protected virtual void Shoot(Vector2 direct, GameObject bullet)
        {
            direct.Normalize();
            var temp = Instantiate(bullet, spawnProjectilePosition.position, Quaternion.identity);
            temp.GetComponent<Projectile>().damage *= _shootDamageMultiply;
            temp.GetComponent<Projectile>().whomShoot = whoControlMe;
            var angle = Mathf.Atan2(direct.y * -1, direct.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            temp.transform.rotation = Quaternion.Slerp(weapon.transform.rotation, rotation, characterStatus.weaponRotateSpeed);

            if (Math.Abs(direct.x) > 0 || Math.Abs(direct.y) > 0)
            {
                temp.GetComponent<Rigidbody2D>().velocity = new Vector2
                (
                    direct.x * characterStatus.projectileSpeed * Time.deltaTime, 
                    direct.y * characterStatus.projectileSpeed * Time.deltaTime * -1
                );
            }
            else
            {
                if (transform.localScale.x < 0)
                {
                    var localScale = temp.transform.localScale;
                    var tempDirect = new Vector2(localScale.x * -1, localScale.y);
                    localScale = tempDirect;
                    temp.transform.localScale = localScale;
                }

                temp.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(Time.deltaTime * characterStatus.projectileSpeed * transform.localScale.x, 0);
            }
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(groundCheckPosition.position, groundCheckRadius);
        }

        public void TakeDamage(float damage, int whomShoot)
        {
            float damageMultiply;
            bool hitByScenario = false;
            int whoGetsThePoint = whomShoot;
            
            if (whomShoot == -1)
            {
                hitByScenario = true;
                 damageMultiply = _scenarioDamageMultiply;
                 whoGetsThePoint = whoControlMe;
            }
            else
                damageMultiply = _takeDamageMultiply;
            
            currentHealth -= damage * damageMultiply;
            UpdateHpBar();
            if (currentHealth <= 0)
            {
                transform.tag = "Untagged";
                SoundManager.instance.PlayAudio(audioHolder.death);
                _powerUpHandler.DropPowerUp();
                GameController.instance.SetPlayerScore(whoGetsThePoint, hitByScenario); 
                GameController.instance.SpawnPlayer(id, whoControlMe);
                DeathEffect();
                Destroy(playerCanvas);
                Destroy(gameObject);
            }
        }

        private void DeathEffect()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        private void UpdateHpBar()
        {
            hpBar.fillAmount = (currentHealth * 1f / characterStatus.maxHealth);
        }

        public void KnockBack(float knockBackForce, float projectilePosition)
        {
            int direction = 1;
            knockBackForce *= _knockBackMultiply;
            if (projectilePosition > transform.position.x)
            {
                knockBackForce *= -1;
                direction = -1;
            }

            _playerRb.velocity = Vector2.zero;
            _canMove = false;
            // var tempTransform = transform;
            // Vector2 temp = tempTransform.position;
            // temp.x += 0.7f * direction;
            // temp.y += 0.5f; 
            // tempTransform.transform.position = temp;
            
            _playerRb.velocity = new Vector2
            (
                knockBackForce * Time.deltaTime,
                _playerRb.velocity.y + ((knockBackForce * Time.deltaTime) * direction)
            );
            StartCoroutine(DelayAfterKnockBack());
        }

        private IEnumerator DelayAfterKnockBack()
        {
            yield return new WaitForSeconds(0.2f);
            _canMove = true;
        }

        private IEnumerator DashEffect()
        {
            while (isDashing)
            {
                yield return new WaitForSeconds(0.03f);
                var temp = Instantiate(dashEffect, transform.position, Quaternion.identity);
                temp.transform.localScale = transform.localScale;
                Destroy(temp, 1f);
            }
        }

        private void JumpEffect(float scaleEffectX, float scaleEffectY)
        {
            var transform1 = transform;
            Vector2 scale = transform1.localScale;
            scale.x = scaleEffectX;
            scale.y = scaleEffectY;
            transform1.localScale = scale;
            StartCoroutine(DelayJumpEffect());
        }

        private IEnumerator DelayJumpEffect()
        {
            yield return new WaitForSeconds(0.1f);
            var transform1 = transform;
            var localScale = transform1.localScale;
            Vector2 scale = localScale;

            scale.x = localScale.x > 0 ? 1 : -1;
            scale.y = 1;
            scale.y = 1;
            localScale = scale;
            transform1.localScale = localScale;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Ground"))
            {
                JumpEffect(1.25f * transform.localScale.x, 0.75f);
                _playerRb.velocity = Vector2.zero;
                _playerRb.angularVelocity = 0;
                _canMidAir = true;
                isMidAir = false;
            }
        }

        public void SetMultiplyMoveSpeed(float multiply)
        {
            characterStatus.moveSpeed *= multiply;
            _auxMoveSpeed = characterStatus.moveSpeed;
        }

        public void SetMultiplyJumpForce(float multiply)
        {
            characterStatus.jumpForce *= multiply;
            characterStatus.doubleJumpForce *= multiply;
        }

        public void SetMultiplyKnockBack(float multiply)
        {
            _knockBackMultiply *= multiply;
        }

        public void SetMultiplyShootDamage(float multiply)
        {
            _shootDamageMultiply *= multiply;
        }

        public void SetMultiplyTakeDamage(float multiply)
        {
            _takeDamageMultiply *= multiply;
        }

        public void SetMultiplyScenarioDamage(float multiply)
        {
            _scenarioDamageMultiply *= multiply;
        }
    }
}