using System;
using System.Collections;
using System.Collections.Generic;
using CustomSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CharacterController : OldInputImplementation
{
    [Header("Configurações")] public int id;
    public int moveSpeed;
    public int jumpForce;
    public JoystickIndex joystickIndex;

    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private LayerMask ground;

    private Rigidbody2D playerRb;
    [SerializeField] private bool canDoubleJump = true;
    [SerializeField] private bool isOnGround;
    private float groundCheckRadius = 0.2f;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        SetJoystick(joystickIndex);
    }

    private void Update()
    {
        Move();

        if (ButtonA())
        {
            if (isOnGround)
            {
                Jump();
            }
            else
            {
                if (ButtonA(true))
                {
                    if (canDoubleJump)
                    {
                        Jump();
                        canDoubleJump = false;
                    }
                }
            }
        }

        CheckGroundCollision();
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
}