namespace Characters
{
    public class CharacterStatus
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

        public CharacterStatus(
            string characterName,
            int id,
            int maxHealth,
            float moveSpeed,
            float jumpForce,
            float doubleJumpForce,
            int dashForce,
            float fireRate,
            float coolDownSkill,
            float midAirDuration,
            float dashDuration,
            float dashCoolDown,
            int weaponRotateSpeed,
            int projectileSpeed
        )
        {
            this.characterName = characterName;
            this.id = id;
            this.maxHealth = maxHealth;
            this.moveSpeed = moveSpeed;
            this.jumpForce = jumpForce;
            this.doubleJumpForce = doubleJumpForce;
            this.dashForce = dashForce;
            this.fireRate = fireRate;
            this.coolDownSkill = coolDownSkill;
            this.midAirDuration = midAirDuration;
            this.dashDuration = dashDuration;
            this.dashCoolDown = dashCoolDown;
            this.weaponRotateSpeed = weaponRotateSpeed;
            this.projectileSpeed = projectileSpeed;
        }
    }
}