using UnityEngine;
using CharacterController = Characters.CharacterController;

namespace Interactables
{
    public class Spike : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float knockBackForce;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
           if (other.CompareTag("Player"))
           {
               print("coll");
               CharacterController tempCharacterController = other.gameObject.GetComponent<CharacterController>();
               tempCharacterController.TakeDamage(damage, -1);
               tempCharacterController.KnockBack(knockBackForce , transform.position.x);
           }
        }
    }
}