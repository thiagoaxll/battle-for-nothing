using UnityEngine;

public class MrSan : CharacterController
{
    [SerializeField] private GameObject especialWeapon;
    [SerializeField] private GameObject defaultWeapon;
    [SerializeField] private GameObject especialProjectile;
    [SerializeField] private GameObject defaultProjectile;
    [SerializeField] private int especialShootQuantity;
    [SerializeField] private bool especialEnable;
    private int auxEspecialShootQuantity;

    protected override void EspecialSkill()
    {
        especialEnable = true;
        base.EspecialSkill();
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        weapon.SetActive(false);

        if (especialEnable)
        {
            auxEspecialShootQuantity = 0;
            weapon = especialWeapon;
            projectile = especialProjectile;
        }
        else
        {
            weapon = defaultWeapon;
            projectile = defaultProjectile;
        }

        weapon.SetActive(true);
    }

    protected override void Shoot(Vector2 direct)
    {
        base.Shoot(direct);
        if (!especialEnable) return;
        auxEspecialShootQuantity++;
        if (auxEspecialShootQuantity < especialShootQuantity) return;
        especialEnable = false;
        ChangeWeapon();
        ResetCoolDown();
    }
}