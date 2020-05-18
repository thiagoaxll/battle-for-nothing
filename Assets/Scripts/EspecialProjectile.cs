using UnityEngine;
using Characters;

public class EspecialProjectile : MonoBehaviour
{
    public float durationTime;
    public GameObject especialObject;
    public int whomShoot;
    public int projectileJrVelocity;

    private void Start()
    {
        Destroy(this.gameObject, durationTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            InstantiateProjectiles(new Vector2(0.25f, 0.25f));
            InstantiateProjectiles(new Vector2(0.50f, 0.50f));
            InstantiateProjectiles(new Vector2(0f, 1f));        
            InstantiateProjectiles(new Vector2(-0.25f, -0.25f));
            InstantiateProjectiles(new Vector2(-0.50f, -0.50f));
            InstantiateProjectiles(new Vector2(1f, 0f));
            Destroy(this.gameObject);
        }
        
        if (other.CompareTag("Shield"))
        {
            if (other.GetComponentInParent<Characters.CharacterController>().whoControlMe != whomShoot)
            {
                Destroy(gameObject);
            }
        }
    }

    private void InstantiateProjectiles(Vector2 direct)
    {
        var temp = Instantiate(especialObject, transform.position, Quaternion.identity);
        temp.GetComponent<Rigidbody2D>().velocity = projectileJrVelocity * Time.deltaTime * direct;
        temp.GetComponent<Projectile>().whomShoot = whomShoot;
    }
}