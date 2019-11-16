using UnityEngine;

public class Jorge : CharacterController
{
    [SerializeField] private GameObject especialBullet;

    protected override void EspecialSkill()
    {
        base.EspecialSkill();
        especialBullet.GetComponent<EspecialProjectile>().whomShoot = id;
        Shoot(playerDirection, especialBullet);
        ResetCoolDown();
    }
}