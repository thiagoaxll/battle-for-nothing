using UnityEngine;
using System;

namespace Characters
{
    public class DjBullet : MonoBehaviour
    {
        public Dj dj;
        private Vector2 _destination;
        public float speed;
        private float _defaultSpeed;
        [SerializeField] private GameObject defaultObjectImage;
        [SerializeField] private GameObject specialObjectImage;

        public float damage;
        public float knockBackForce;
        public int whomShoot;
        public int whoControlMe;

        private void Start()
        {
            _defaultSpeed = speed;
        }

        public void SetSpecialSpeed(float multiply)
        {
            speed *= multiply;
            ChangeImage(false);
        }

        public void SetDefaultSpeed()
        {
            speed = _defaultSpeed;
            ChangeImage(true);
        }

        private void ChangeImage(bool enable)
        {
            defaultObjectImage.SetActive(enable);
            specialObjectImage.SetActive(!enable);
        }

        public void SetDestination(Vector2 destination)
        {
            _destination = destination;
        }


        private void Update()
        {
            if (dj.canShoot)
            {
                transform.position = dj.spawnProjectilePosition.position;
            }
            else
            {
                if (!dj.diskGoing) _destination = dj.spawnProjectilePosition.position;
                MoveBullet();
                if (Math.Abs(transform.position.x - _destination.x) < 0.1f &&
                    Math.Abs(transform.position.y - _destination.y) < 0.1f)
                {
                    dj.DestinationArrived();
                }
            }
        }

        private void MoveBullet()
        {
            transform.position = Vector2.MoveTowards(transform.position, _destination, speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.GetComponent<CharacterController>().whoControlMe != whomShoot)
                {
                    other.GetComponent<CharacterController>().TakeDamage(damage, whomShoot);
                    other.GetComponent<CharacterController>()
                        .KnockBack(knockBackForce, transform.position.x);
                }
            }
        }
    }
}