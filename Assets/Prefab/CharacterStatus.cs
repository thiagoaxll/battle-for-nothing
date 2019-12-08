using UnityEngine;

namespace Prefab
{
   [CreateAssetMenu(fileName = "CharacterStatus", menuName = "GameObjects/CharacterStatus")] 
    public class CharacterStatus : ScriptableObject
    {
        public string characterName;
        public int id;
        public int maxHealth;
        public float moveSpeed;
        public float jumpForce;
        public float doubleJumpForce;
        public int dashForce;
        public float fireRate;
        public float coolDownSkill;
        public float midAirDuration;
        public float dashDuration;
        public float dashCoolDown;
        public int weaponRotateSpeed;
        public int projectileSpeed;
    }
}