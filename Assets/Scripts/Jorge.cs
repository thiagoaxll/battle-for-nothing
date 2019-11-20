using UnityEngine;

public class Jorge : CharacterController
{
    [SerializeField] private GameObject especialBullet;

    protected override void EspecialSkill()
    {
        base.EspecialSkill();
        especialBullet.GetComponent<EspecialProjectile>().whomShoot = whoControlMe;
        Shoot(playerDirection, especialBullet);
        ResetCoolDown();
    }
}