using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float durationTime;
    public float knockBackForce;
    public Rigidbody2D projectileRb;
    public int whomShoot;

    private void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, durationTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().TakeDamage(damage, whomShoot);
            other.GetComponent<CharacterController>().KnockBack(knockBackForce, transform.position.x);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            projectileRb.velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}