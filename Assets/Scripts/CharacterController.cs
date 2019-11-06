using CustomSystem;
using UnityEngine;
using System;

public class CharacterController : OldInputImplementation
{
    [Header("Configuration")] public int id;
    public int moveSpeed;
    public int jumpForce;
    public int weaponRotateSpeed;
    public int projectileSpeed;
    public JoystickIndex joystickIndex;

    [Header("References")] [SerializeField]
    private Transform groundCheckPosition;

    [SerializeField] private LayerMask ground;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform spawnProjectilePosition;

    [Header("Control")]
    public int hp;
    [SerializeField] private bool canDoubleJump = true;
    [SerializeField] private bool isOnGround;
    [SerializeField] private bool lookingLeft;

    private Rigidbody2D playerRb;
    private float groundCheckRadius = 0.2f;
    private Vector2 direction;

    private int auxMoveSpeed;

    private void Start()
    {
        auxMoveSpeed = moveSpeed;
        playerRb = GetComponent<Rigidbody2D>();
        SetJoystick(joystickIndex);
    }

    private void Update()
    {
        Move();

        if (ButtonA(true))
        {
            if (isOnGround)
            {
                Jump();
            }
            else
            {
                if (ButtonA())
                {
                    if (canDoubleJump)
                    {
                        Jump();
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

    private void Jump()
    {
        var jumpVector = new Vector2(playerRb.velocity.x, jumpForce * Time.deltaTime);
        playerRb.velocity = jumpVector;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(groundCheckPosition.position, groundCheckRadius);
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
}