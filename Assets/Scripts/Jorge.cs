using UnityEngine;

public class Jorge : CharacterController
{
    [SerializeField] private GameObject especialBullet;

    protected override void EspecialSkill()
    {
        base.EspecialSkill();
        Shoot(playerDirection, especialBullet);
        ResetCoolDown();
    }
}