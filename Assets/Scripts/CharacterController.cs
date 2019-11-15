using CustomSystem;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class CharacterController : LegacyInputImplementation
{
    [Header("Configuration")] public int id;
    public int maxHealth;
    public int moveSpeed;
    public int jumpForce;
    public int dashForce;
    public float coolDownSkill;
    public float midAirDuration;
    public float dashDuration;
    public float dashCoolDown;
    public int doubleJumpForce;
    public int weaponRotateSpeed;
    public int projectileSpeed;
    public JoystickIndex joystickIndex;

    [Header("References")] [SerializeField]
    private Transform groundCheckPosition;

    [SerializeField] private Image hpBar;
    [SerializeField] private Image coolDownBar;

    [SerializeField] private LayerMask ground;
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected GameObject weapon;
    [SerializeField] private GameObject dashEffect;
    [SerializeField] private Transform spawnProjectilePosition;
    [SerializeField] private GameObject playerCanvas;

    [Header("Control")] [SerializeField] private bool canDoubleJump = true;
    [SerializeField] private bool isOnGround;
    [SerializeField] private bool lookingLeft;

    private Rigidbody2D playerRb;
    [SerializeField] private float groundCheckRadius;
    private Vector2 direction;

    private int auxMoveSpeed;
    private int currentHealth;
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
    [SerializeField] private float auxMidAirDuration;

    private void Start()
    {
        auxMidAirDuration = midAirDuration;
        currentHealth = maxHealth;
        auxMoveSpeed = moveSpeed;
        playerRb = GetComponent<Rigidbody2D>();
        defaultGravity = playerRb.gravityScale;
        SetJoystick(joystickIndex);
        CustomStart();
        playerCanvas.transform.SetParent(null);
    }

    protected virtual void CustomStart()
    {
    }

    private void Update()
    {
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

        if (ButtonLb(true) || ButtonRb(true))
        {
            CheckMidAirStatus();
        }
        else
        {
            NormalState();
        }

        if (ButtonX())
        {
            CheckForShoot(playerDirection);
        }

        if (ButtonY() && canDash)
        {
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
        playerCanvas.transform.position = transform.position;
    }

    private void CheckMidAirStatus()
    {
        Aim();
        if (canMidAir && !isOnGround)
        {
            auxMidAirDuration = midAirDuration;
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
        if (auxCoolDownSkill < coolDownSkill)
        {
            auxCoolDownSkill += Time.deltaTime;
            coolDownBar.fillAmount = (auxCoolDownSkill * 1f / coolDownSkill);
        }
        else if (auxCoolDownSkill >= coolDownSkill && !canUseSkill)
        {
            canUseSkill = true;
        }
    }

    protected virtual void ResetCoolDown()
    {
        canUseSkill = false;
        auxCoolDownSkill = 0;
    }

    protected virtual void CustomUpdate()
    {
    }

    protected virtual void EspecialSkill()
    {
        coolDownBar.fillAmount = 0;
    }

    private void CheckForShoot(Vector2 shootDirection)
    {
        Shoot(aiming ? shootDirection : Vector2.zero, projectile);
    }

    private void CheckForJump()
    {
        if (isOnGround)
        {
            Jump(jumpForce);
        }
        else
        {
            if (!ButtonA()) return;
            if (!canDoubleJump) return;
            Jump(doubleJumpForce);
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
        moveSpeed = auxMoveSpeed;
        if (lookingLeft)
        {
            RotateWeapon(new Vector2(-180, 0));
        }
        else
        {
            RotateWeapon(new Vector2(-180, 0));
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
        moveSpeed = auxMoveSpeed / 5;
        var v = ButtonDirection();
        if (lookingLeft)
        {
            if (Math.Abs(v.x) > 0 || Math.Abs(v.y) > 0)
            {
                RotateWeapon(new Vector2(v.x, v.y * -1));
            }
            else
            {
                RotateWeapon(new Vector2(-180, 0));
            }
        }
        else
        {
            RotateWeapon(new Vector2(v.x * -1, v.y));
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
            weapon.transform.rotation, rotation, weaponRotateSpeed * Time.deltaTime
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
        playerRb.velocity = new Vector2(ButtonDirection().x * moveSpeed * Time.deltaTime, playerRb.velocity.y);
    }

    private void Jump(float force)
    {
        var jumpVector = new Vector2(playerRb.velocity.x, force * Time.deltaTime);
//        var resetY = new Vector2(playerRb.velocity.x, 0);
//        playerRb.angularVelocity = 0;
//        playerRb.velocity = resetY;
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
        var velocity = new Vector2(jumpForce * Time.deltaTime * dashDirection.x,
            jumpForce * Time.deltaTime * dashDirection.y * -1);
        playerRb.velocity = velocity;
        StartCoroutine(DashDurationDelay(dashDuration));
        StartCoroutine(DashCoolDown(dashCoolDown));
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
        var temp = Instantiate(bullet, spawnProjectilePosition.position, Quaternion.identity);
        temp.GetComponent<Projectile>().whomShoot = id;
        var angle = Mathf.Atan2(direct.y * -1, direct.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        temp.transform.rotation = Quaternion.Slerp(weapon.transform.rotation, rotation, weaponRotateSpeed);

        if (Math.Abs(direct.x) > 0 || Math.Abs(direct.y) > 0)
        {
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2
            (
                direct.x * projectileSpeed * Time.deltaTime, direct.y * projectileSpeed * Time.deltaTime * -1
            );
        }
        else
        {
            temp.GetComponent<Rigidbody2D>().velocity =
                new Vector2(Time.deltaTime * projectileSpeed * transform.localScale.x, 0);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(groundCheckPosition.position, groundCheckRadius);
    }

    public void TakeDamage(int damage, int whomShoot)
    {
        currentHealth -= damage;
        UpdateHpBar();
        if (currentHealth <= 0)
        {
            GameController.instance.SetPlayerScore(whomShoot);
            GameController.instance.SpawnPlayer(id);
            Destroy(playerCanvas);
            Destroy(this.gameObject);
        }
    }

    private void UpdateHpBar()
    {
        hpBar.fillAmount = (currentHealth * 1f / maxHealth);
    }

    public void KnockBack(float knockBackForce, float projectilePosition)
    {
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
            yield return new WaitForSeconds(0.1f);
            var temp = Instantiate(dashEffect, transform.position, Quaternion.identity);
            Destroy(temp, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag($"Ground"))
        {
            playerRb.velocity = Vector2.zero;
            playerRb.angularVelocity = 0;
            canMidAir = true;
            isMidAir = false;
        }
    }
}