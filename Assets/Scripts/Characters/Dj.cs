using System.Collections;
using UnityEngine;
using System;

namespace Characters
{
    public class Dj : CharacterController
    {
        [SerializeField] private float bulletMaxDistanceMulti;
        [SerializeField] private float specialBulletDistanceMultiply;
        [SerializeField] private float specialDuration;
        [SerializeField] private float specialSpeedMultiply;
        public bool diskGoing;
        public GameObject diskBullet;
        
        private bool _specialEnable;
        private DjBullet _djBullet;
        private float _defaultMaxDistance;
        private GameObject _bulletObjectReference;

        protected override void CustomStart()
        {
            _bulletObjectReference = Instantiate(diskBullet, transform.position, Quaternion.identity);
            _djBullet = _bulletObjectReference.GetComponent<DjBullet>();
            _djBullet.dj = this;
            _defaultMaxDistance = bulletMaxDistanceMulti;
            _djBullet.whomShoot = whoControlMe;
        }

        protected override void EspecialSkill()
        {
            base.EspecialSkill();
            if (!_specialEnable)
            {
                bulletMaxDistanceMulti *= specialBulletDistanceMultiply;
                _specialEnable = true;
                _djBullet.SetSpecialSpeed(specialSpeedMultiply);
                StartCoroutine(SpecialDuration());
            }
        }

        private IEnumerator SpecialDuration()
        {
            yield return new WaitForSeconds(specialDuration);
            _specialEnable = false;
            _djBullet.SetDefaultSpeed();
            bulletMaxDistanceMulti = _defaultMaxDistance;
            ResetCoolDown();
        }

        protected override void Shoot(Vector2 direct, GameObject bullet)
        {
            if (Math.Abs(direct.x) <= 0.01f && Math.Abs(direct.y) <= 0.01f)
            {
                direct = new Vector2(transform.localScale.x, 0);
            }

            var tempDirection = transform.position;
            tempDirection.x += bulletMaxDistanceMulti * direct.x;
            tempDirection.y += bulletMaxDistanceMulti * direct.y * -1;
            _djBullet.SetDestination(tempDirection);
            diskGoing = true;
            canShoot = false;
        }

        public void DestinationArrived()
        {
            if (diskGoing)
            {
                diskGoing = false;
                _djBullet.SetDestination(spawnProjectilePosition.transform.position);
            }
            else
            {
                canShoot = true;
            }
        }

        protected override void FireRateCalculate()
        {
            // Its overwritten so the variable canShoot will not be set to true like in other characters
        }

        protected override void DestroyPlayer()
        {
            Destroy(_bulletObjectReference);
            base.DestroyPlayer();
        }
    }
}