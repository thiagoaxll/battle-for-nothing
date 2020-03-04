using CustomSystem;
using UnityEngine;
using System;
using System.Collections;
using CustomSystem.Audio;
using Prefab;
using TMPro;
using UnityEngine.UI;

public class CharacterController : LegacyInputImplementation
{
    [Header("Configuration")] public int id;

    public CharacterStatus characterStatus;

//    public int maxHealth;
    public float currentHealth;
//    public float moveSpeed;
//    public float jumpForce;
//    public int dashForce;
//    public float fireRate;
//    public float coolDownSkill;
//    public float midAirDuration;
//    public float dashDuration;
//    public float dashCoolDown;
//    public float doubleJumpForce;
//    public int weaponRotateSpeed;
//    public int projectileSpeed;

    private float damageScenarioMultiply = 1;
    private float shootDamageMultiply = 1;
    private float takeDamageMultiply = 1;
    private float knockBackMultiply = 1;

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

    private Rigidbody2D playerRb;
    [SerializeField] private float groundCheckRadius;
    private Vector2 direction;

    private float auxMoveSpeed;
    private bool canMove = true;
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    private bool aiming;
    private bool canUseSkill;
    private float auxCoolDownSkill;
    protected Vector2 playerDirection;
    private float defaultGravity;
    private bool canMidAir = true;
    [SerializeField] private bool isMidAir;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float auxMidAirDuration;
    private PowerUpHandler powerUpHandler;
    [HideInInspector] public AudioHolder audioHolder;
    public int whoControlMe;
    private float auxFireRate;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        powerUpHandler = GetComponent<PowerUpHandler>();
        playerCanvas.transform.SetParent(null);
        StartCoroutine(DelayStayImmune());
    }

    private void Start()
    {
        auxFireRate = characterStatus.fireRate;
        audioHolder = GetComponent<AudioHolder>();
        auxMidAirDuration = characterStatus.midAirDuration;
        currentHealth = characterStatus.maxHealth;
        auxMoveSpeed = characterStatus.moveSpeed;
        defaultGravity = playerRb.gravityScale;


        CheckJoystick();

        indicatorTxt.SetText("P" + (whoControlMe + 1));

        CustomStart();
    }

    private void CheckJoystick()
    {
        if (whoControlMe == 0)
        {
            SetJoystick(JoystickIndex.JoystickOne);
        }

        else if (whoControlMe == 1)
        {
            SetJoystick(JoystickIndex.JoystickTwo);
        }

        else if (whoControlMe == 2)
        {
            SetJoystick(JoystickIndex.JoystickThree);
        }
        else
        {
            SetJoystick(JoystickIndex.JoystickFour);
        }
    }

    IEnumerator DelayStayImmune()
    {
        var temp = Instantiate(shield, transform.position, Quaternion.identity);
        temp.transform.SetParent(transform);
        transform.tag = "Untagged";
        yield return new WaitForSeconds(2.5f);
        transform.tag = "Player";
        Destroy(temp);
    }

    protected virtual void CustomStart()
    {
    }
    private void Update()
    {
        if (!GameController.instance.gameRunning) return;
        playerDirection = ButtonDirection();
        if (canMove)
        {
            Move();
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
            NormalState();
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

        if (ButtonB() && canUseSkill)
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
            auxFireRate -= Time.deltaTime;
            if (auxFireRate <= 0)
            {
                canShoot = true;
                auxFireRate = characterStatus.fireRate;
            }
        }
    }

    private void LockToAim()
    {
        if (isOnGround)
        {
            Aim();
            playerRb.velocity = Vector2.zero;
        }
    }

    private void CheckMidAirStatus()
    {
        Aim();
        if (canMidAir && !isOnGround)
        {
            auxMidAirDuration = characterStatus.midAirDuration;
            canMidAir = false;
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
        if (auxCoolDownSkill < characterStatus.coolDownSkill)
        {
            auxCoolDownSkill += Time.deltaTime;
            coolDownBar.fillAmount = (auxCoolDownSkill * 1f / characterStatus.coolDownSkill);
        }
        else if (auxCoolDownSkill >= characterStatus.coolDownSkill && !canUseSkill)
        {
            canUseSkill = true;
            coolDownBar.color = Color.green;
        }
    }

    protected virtual void ResetCoolDown()
    {
        canUseSkill = false;
        auxCoolDownSkill = 0;
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
        Shoot(aiming ? shootDirection : Vector2.zero, projectile);
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

    private void NormalState()
    {
        if (canDash)
        {
            playerRb.gravityScale = defaultGravity;
        }

        aiming = false;
        characterStatus.moveSpeed = auxMoveSpeed;
        if (lookingLeft)
        {
            RotateWeapon(new Vector2(180, 0));
        }
        else
        {
            RotateWeapon(new Vector2(180, 0));
        }
    }

    private void MidAirEffect()
    {
        var currentSpeed = playerRb.velocity;
        currentSpeed.x /= 2;
        currentSpeed.y /= 2;
        playerRb.velocity = currentSpeed;
        playerRb.gravityScale = 2f;
    }

    private void Aim()
    {
        aiming = true;
        characterStatus.moveSpeed = auxMoveSpeed / 5;
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

    private void Move()
    {
        playerRb.velocity = new Vector2(
            ButtonDirection().x * characterStatus.moveSpeed * Time.deltaTime, playerRb.velocity.y
        );
    }

    private void Jump(float force)
    {
        SoundManager.instance.PlayAudio(audioHolder.jumpEffect);
        var jumpVector = new Vector2(playerRb.velocity.x, force * Time.deltaTime);
        playerRb.velocity = jumpVector;
    }

    private void CancelJump()
    {
        if (playerRb.velocity.y > 0)
        {
            var velocity = playerRb.velocity;
            velocity.y *= 0.25f;
            playerRb.velocity = velocity;
        }
    }

    private void Dash(Vector2 dashDirection)
    {
        playerRb.gravityScale = 0;
        canMove = false;
        canDash = false;
        isDashing = true;
        StartCoroutine(DashEffect());
        var velocity = new Vector2(characterStatus.dashForce * Time.deltaTime * dashDirection.x,
            characterStatus.dashForce * Time.deltaTime * dashDirection.y * -1);
        playerRb.velocity = velocity;
        StartCoroutine(DashDurationDelay(characterStatus.dashDuration));
        StartCoroutine(DashCoolDown(characterStatus.dashCoolDown));
    }

    private IEnumerator DashDurationDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerRb.gravityScale = defaultGravity;
        canMove = true;
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
        temp.GetComponent<Projectile>().damage *= shootDamageMultiply;
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
                var tempDirect = new Vector2(temp.transform.localScale.x * -1, temp.transform.localScale.y);
                temp.transform.localScale = tempDirect;
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
        currentHealth -= damage * takeDamageMultiply;
        UpdateHpBar();
        if (currentHealth <= 0)
        {
//            GetComponent<CircleCollider2D>().enabled = false;
            transform.tag = "Untagged";
            SoundManager.instance.PlayAudio(audioHolder.death);
            powerUpHandler.DropPowerUp();
            GameController.instance.SetPlayerScore(whomShoot);
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
        knockBackForce *= knockBackMultiply;
        if (projectilePosition > transform.position.x)
        {
            knockBackForce *= -1;
        }

        canMove = false;
        playerRb.velocity = new Vector2
        (
            knockBackForce * Time.deltaTime,
            playerRb.velocity.y + (knockBackForce * Time.deltaTime / 2)
        );
        StartCoroutine(DelayAfterKnockBack());
    }

    private IEnumerator DelayAfterKnockBack()
    {
        yield return new WaitForSeconds(0.2f);
        canMove = true;
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
        Vector2 scale = transform1.localScale;

        scale.x = transform1.localScale.x > 0 ? 1 : -1;
        scale.y = 1;
        scale.y = 1;
        transform1.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            JumpEffect(1.25f * transform.localScale.x, 0.75f);
            playerRb.velocity = Vector2.zero;
            playerRb.angularVelocity = 0;
            canMidAir = true;
            isMidAir = false;
        }
    }

    public void SetMultiplyMoveSpeed(float multiply)
    {
        characterStatus.moveSpeed *= multiply;
        auxMoveSpeed = characterStatus.moveSpeed;
    }

    public void SetMultiplyJumpForce(float multiply)
    {
        characterStatus.jumpForce *= multiply;
        characterStatus.doubleJumpForce *= multiply;
    }

    public void SetMultiplyKnockBack(float multiply)
    {
        knockBackMultiply *= multiply;
    }

    public void SetMultiplyShootDamage(float multiply)
    {
        shootDamageMultiply *= multiply;
    }

    public void SetMultiplyTakeDamage(float multiply)
    {
        takeDamageMultiply *= multiply;
    }

    public void SetMultiplyScenarioDamage(float multiply)
    {
        damageScenarioMultiply *= multiply;
    }
}