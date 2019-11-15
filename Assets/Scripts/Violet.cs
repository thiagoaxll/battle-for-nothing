using UnityEngine;

public class Violet : CharacterController
{
    protected override void EspecialSkill()
    {
        base.EspecialSkill();
        if (playerDirection.x == 0)
        {
            Shoot(new Vector2(transform.localScale.x, playerDirection.y + 0.2f), projectile);
            Shoot(new Vector2(transform.localScale.x, playerDirection.y + 0.1f), projectile);
            Shoot(new Vector2(transform.localScale.x, playerDirection.y), projectile);
            Shoot(new Vector2(transform.localScale.x, playerDirection.y - 0.1f), projectile);
            Shoot(new Vector2(transform.localScale.x, playerDirection.y - 0.2f), projectile);
        }
        else
        {
            Shoot(new Vector2(playerDirection.x, playerDirection.y + 0.2f), projectile);
            Shoot(new Vector2(playerDirection.x, playerDirection.y + 0.1f), projectile);
            Shoot(new Vector2(playerDirection.x, playerDirection.y), projectile);
            Shoot(new Vector2(playerDirection.x, playerDirection.y - 0.1f), projectile);
            Shoot(new Vector2(playerDirection.x, playerDirection.y - 0.2f), projectile);
        }

        ResetCoolDown();
    }
}