using UnityEngine;

public class Violet : CharacterController
{
    protected override void EspecialSkill()
    {
        base.EspecialSkill();
//        if (playerDirection.x == 0)
//        {
//            Shoot(new Vector2(transform.localScale.x, playerDirection.y + 0.2f));
//            Shoot(new Vector2(transform.localScale.x, playerDirection.y + 0.1f));
//            Shoot(new Vector2(transform.localScale.x, playerDirection.y));
//            Shoot(new Vector2(transform.localScale.x, playerDirection.y - 0.1f));
//            Shoot(new Vector2(transform.localScale.x, playerDirection.y - 0.2f));
//        }
//        else
//        {
            Shoot(new Vector2(playerDirection.x + 0.1f, playerDirection.y + 0.2f));
            Shoot(new Vector2(playerDirection.x + 0.2f, playerDirection.y + 0.1f));
            Shoot(new Vector2(playerDirection.x, playerDirection.y));
            Shoot(new Vector2(playerDirection.x - 0.1f, playerDirection.y - 0.1f));
            Shoot(new Vector2(playerDirection.x - 0.2f, playerDirection.y - 0.2f));
//        }


//        
//        Shoot(new Vector2(playerDirection.x -0.1f, playerDirection.y -0.1f)); 
//        Shoot(new Vector2(playerDirection.x -0.2f, playerDirection.y -0.2f)); 
//        Shoot(new Vector2(playerDirection.x -0.3f, playerDirection.y -0.3f)); 
//        Shoot(new Vector2(playerDirection.x -0.4f, playerDirection.y -0.4f)); 
//        Shoot(new Vector2(playerDirection.x -0.5f, playerDirection.y -0.5f)); 
        ResetCoolDown();
    }
}