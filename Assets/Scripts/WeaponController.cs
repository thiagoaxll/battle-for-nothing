using System;
using System.Collections;
using System.Collections.Generic;
using CustomSystem;
using UnityEngine;

public class WeaponController : OldInputImplementation
{
    public float rotationSpeed;
    public float projectileSpeed;
    public Vector2 direction;
    public GameObject projectile;

    private void Start()
    {
        SetJoystick(JoystickIndex.JoystickOne);
    }

    private void Update()
    {
        direction = RightAnalog();
        RotateWeapon();

        if (ButtonX(true))
        {
            InstantiateBullet();
        }
    }

    private void RotateWeapon()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void InstantiateBullet()
    {
        var temp = Instantiate(projectile, transform.position, Quaternion.identity);

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        temp.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        
        temp.GetComponent<SpriteRenderer>().color = GetComponentInChildren<SpriteRenderer>().color;
        if (direction.x != 0 || direction.y != 0)
        {
            temp.GetComponent<Rigidbody2D>().velocity = Time.deltaTime * projectileSpeed * direction.normalized;
        }
        else
        {
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(Time.deltaTime * projectileSpeed, 0);
        }
       
    }
    
}