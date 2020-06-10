using System.Collections;
using  UnityEngine;

namespace Characters
{
    public class Ellie : CharacterController
    {
        public float specialDuration;
        public GameObject specialBullet;
        public GameObject defaultBullet;
        public Animator weaponAnimator;
        
        private bool _specialEnable;
        protected  override void EspecialSkill()
        {
            base.EspecialSkill();
            projectile = specialBullet;
            StartCoroutine(SpecialDuration());
            weaponAnimator.SetTrigger($"special");
        }

        private void DisableSpecial()
        {
            projectile = defaultBullet;
            weaponAnimator.SetTrigger($"default");
        }

        private IEnumerator SpecialDuration()
        {
            yield return new WaitForSeconds(specialDuration);
            DisableSpecial();
            ResetCoolDown();
        }
    }
}