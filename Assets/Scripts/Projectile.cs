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
        Destroy(this.gameObject, durationTime);
    }
    
}
