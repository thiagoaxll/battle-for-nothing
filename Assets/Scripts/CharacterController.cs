using CustomSystem;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class CharacterController : OldInputImplementation
{
    [Header("Configuration")] public int id;
    public int maxHealth;
    public int moveSpeed;
    public int jumpForce;
    public int dashForce;
    public float dashDuration;
    public float dashCoolDown;
    public int doubleJumpForce;
    public int weaponRotateSpeed;
    public int projectileSpeed;
    public JoystickIndex joystickIndex;

    [Header("References")] [SerializeField]
    private Transform groundCheckPosition;

    [SerializeField] private Image hpBar;

    [SerializeField] private LayerMask ground;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform spawnProjectilePosition;

    [Header("Control")] [SerializeField] private bool canDoubleJump = true;
    [SerializeField] private bool isOnGround;
    [SerializeField] private bool lookingLeft;

    private Rigidbody2D playerRb;
    private float groundCheckRadius = 0.2f;
    private Vector2 direction;

    private int auxMoveSpeed;
    private int currentHealth;
    private bool canMove = true;
    private bool canDash = true;

    private void Start()
    {
        currentHealth = maxHealth;
        auxMoveSpeed = moveSpeed;
        playerRb = GetComponent<Rigidbody2D>();
        SetJoystick(joystickIndex);
    }

    private void Update()
    {
        if (canMove)
        {
            Move();
        }

        if (ButtonA(true))
        {
            if (isOnGround)
            {
                Jump(jumpForce);
            }
            else
            {
                if (ButtonA())
                {
                    if (canDoubleJump)
                    {
                        Jump(doubleJumpForce);
                        canDoubleJump = false;
                    }
                }
            }
        }

        if (ButtonLb(true) || ButtonRb(true))
        {
            moveSpeed = 0;
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
        else
        {
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

        if (ButtonX())
        {
            Shoot(ButtonDirection());
        }

        if (ButtonY() && canDash)
        {
            Dash();
        }

        CheckGroundCollision();
        CheckPlayerDirection(ButtonDirection().x);
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
        playerRb.velocity = jumpVector;
    }

    private void Dash()
    {
        playerRb.gravityScale = 0;
        canMove = false;
        canDash = false;
        var velocity = new Vector2(jumpForce * transform.localScale.x * Time.deltaTime, 0);
        playerRb.velocity = velocity;
        StartCoroutine(DashDurationDelay(dashDuration));
        StartCoroutine(DashCoolDown(dashCoolDown));
    }

    private IEnumerator DashDurationDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerRb.gravityScale = 1;
        canMove = true;
    }

    private IEnumerator DashCoolDown(float coolDown)
    {
        yield return new WaitForSeconds(coolDown);
        canDash = true;
    }

    private void Shoot(Vector2 direct)
    {
        var temp = Instantiate(projectile, spawnProjectilePosition.position, Quaternion.identity);

        float angle = Mathf.Atan2(direct.y * -1, direct.x) * Mathf.Rad2Deg;
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHpBar();
        if (currentHealth <= 0)
        {
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
        playerRb.velocity = new Vector2(knockBackForce * Time.deltaTime, playerRb.velocity.y);
        StartCoroutine(DelayAfterKnockBack());
    }

    IEnumerator DelayAfterKnockBack()
    {
        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }
}