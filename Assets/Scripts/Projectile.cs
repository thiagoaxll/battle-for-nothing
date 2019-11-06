using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float durationTime;
    public Rigidbody2D projectileRb;

    private void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, durationTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().takeDamage(damage);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            projectileRb.velocity = Vector2.zero;
        }
    }
}