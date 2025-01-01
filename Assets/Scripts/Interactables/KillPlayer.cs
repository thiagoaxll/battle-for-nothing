using CharacterController = Characters.CharacterController;
using UnityEngine;

namespace Interactables
{
    public class KillPlayer : MonoBehaviour
    {
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
                SetKillPlayer(other);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if(other.transform.CompareTag("Player"))
                SetKillPlayer(other);
        }
        private static void SetKillPlayer(Collision2D other)
        {
            CharacterController tempCharacterController = other.gameObject.GetComponent<CharacterController>();
            tempCharacterController.TakeDamage(9999, -2);
        }
    }
}