using System.Collections;
using UnityEngine;

namespace Characters
{
    public class Dj : CharacterController
    {
        [SerializeField] private float bulletMaxDistanceMulti;
        [SerializeField] private float delayToBulletReturn;
        [SerializeField] private float diskSpeed;
        private Transform _destinationPosition = new RectTransform();
        public bool diskGoing;

        private DjBullet _djBullet;
        public GameObject bullet;

        
        protected override void CustomStart()
        {
            var temp = Instantiate(bullet, transform.position, Quaternion.identity);
            _djBullet = temp.GetComponent<DjBullet>();
            _djBullet.dj = this;
        }

        protected override void EspecialSkill()
        {
        }

        protected override void Shoot(Vector2 direct, GameObject bullet)
        {
            _djBullet.SetDestination(direct);
            diskGoing = true;
            canShoot = false;
        }

        protected override void CustomUpdate()
        {
            // if(canShoot) return;
            //
            // if (_diskGoing)
            // {
            //     disk.transform.position = MoveDisk(disk.transform, _destinationPosition, diskSpeed);
            //     if (disk.transform.position == _destinationPosition.position)
            //     {
            //         _diskGoing = false;
            //     }
            // }
            // else
            // {
            //    disk.transform.position = MoveDisk(disk.transform, spawnProjectilePosition, diskSpeed);
            //    if (disk.transform.position == spawnProjectilePosition.transform.position)
            //    {
            //        canShoot = true;
            //    }
            // }

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
        }
    }
}