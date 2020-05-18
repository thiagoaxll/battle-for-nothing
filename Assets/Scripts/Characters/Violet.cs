using UnityEngine;

namespace Characters
{
    public class Violet : CharacterController
    {
        public GameObject especialProjectile;
        protected override void EspecialSkill()
        {
            base.EspecialSkill();
            if (playerDirection.x == 0)
            {
                Shoot(new Vector2(transform.localScale.x, playerDirection.y + 0.2f), especialProjectile);
                Shoot(new Vector2(transform.localScale.x, playerDirection.y + 0.1f), especialProjectile);
                Shoot(new Vector2(transform.localScale.x, playerDirection.y), especialProjectile);
                Shoot(new Vector2(transform.localScale.x, playerDirection.y - 0.1f), especialProjectile);
                Shoot(new Vector2(transform.localScale.x, playerDirection.y - 0.2f), especialProjectile);
            }
            else
            {
                Shoot(new Vector2(playerDirection.x, playerDirection.y + 0.2f), especialProjectile);
                Shoot(new Vector2(playerDirection.x, playerDirection.y + 0.1f), especialProjectile);
                Shoot(new Vector2(playerDirection.x, playerDirection.y), especialProjectile);
                Shoot(new Vector2(playerDirection.x, playerDirection.y - 0.1f), especialProjectile);
                Shoot(new Vector2(playerDirection.x, playerDirection.y - 0.2f), especialProjectile);
            }

            ResetCoolDown();
        }
    }
}