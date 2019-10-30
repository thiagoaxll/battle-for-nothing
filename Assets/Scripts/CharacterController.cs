using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CharacterController : MonoBehaviour
{
    [Header("Configurações")] public int id;

    public int moveSpeed;
    public int jumpForce;

    public Rigidbody2D playerRb;


    private MyInput control;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        control = new MyInput();
        control.Enable();
        control.MY_CONTROL.A.performed += ctx => jump();
        control.MY_CONTROL.LEFT.performed += ctx => left();
        control.MY_CONTROL.RIGHT.performed += ctx => right();
    }

    void jump()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
    }

    public void left()
    {
        playerRb.velocity = new Vector2(moveSpeed * -1, playerRb.velocity.y);
    }

    public void right()
    {
        playerRb.velocity = new Vector2(moveSpeed, playerRb.velocity.y);
    }
}