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

    public Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        SetJoystick(joystickIndex);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        playerRb.velocity = new Vector2(ButtonDirection().x * moveSpeed * Time.deltaTime, ButtonDirection().y * moveSpeed * Time.deltaTime);
    }
}