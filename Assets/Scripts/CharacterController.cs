using System;
using System.Collections;
using System.Collections.Generic;
using CustomSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CharacterController : InputImplementation
{
    [Header("Configurações")] public int id;

    public int moveSpeed;
    public int jumpForce;

    public Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        StartController();
    }

    private void Update()
    {
        playerRb.velocity = new Vector2(ButtonDirection().x * moveSpeed * Time.deltaTime, playerRb.velocity.y);
    }
}