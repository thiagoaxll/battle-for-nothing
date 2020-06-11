using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private bool throughWall;
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

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            if (other.GetComponentInParent<Characters.CharacterController>().whoControlMe != whomShoot)
            {
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Characters.CharacterController>().whoControlMe != whomShoot)
            {
                other.GetComponent<Characters.CharacterController>().TakeDamage(damage, whomShoot);
                other.GetComponent<Characters.CharacterController>().KnockBack(knockBackForce, transform.position.x);
                Destroy(this.gameObject);
            }
        }

        if (other.CompareTag("Ground"))
        {
            if (!stayAlive)
            {
                projectileRb.velocity = Vector2.zero;
            }

            if (!throughWall)
            {
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
}