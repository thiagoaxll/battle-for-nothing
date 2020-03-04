using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float durationTime;
    public float knockBackForce;
    public Rigidbody2D projectileRb;
    public int whomShoot;
    public int whoControlMe;
    public bool stayAlive;

    private void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, durationTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Shield"))
        {
            if (other.GetComponentInParent<CharacterController>().whoControlMe != whomShoot)
            {
                Destroy(gameObject);
            }
            
        }
        
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<CharacterController>().whoControlMe != whomShoot)
            {
                other.GetComponent<CharacterController>().TakeDamage(damage, whomShoot);
                other.GetComponent<CharacterController>().KnockBack(knockBackForce, transform.position.x);
                Destroy(this.gameObject);
            }
        }

        if (other.CompareTag("Ground"))
        {
            if (!stayAlive)
            {
                projectileRb.velocity = Vector2.zero;
            }

            try
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}