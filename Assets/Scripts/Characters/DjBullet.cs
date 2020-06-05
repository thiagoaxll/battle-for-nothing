using UnityEngine;

namespace Characters
{
    public class DjBullet : MonoBehaviour
    {
        public Dj dj;
        private Vector2 _destination;
        public float speed;
       private void Start()
       {
        
       }

       public void SetDestination(Vector2 destination)
       {
           this._destination = destination;
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
                if (transform.position.x == _destination.x && transform.position.y == _destination.y)
                {
                    dj.DestinationArrived();
                }
            }
        }

        private void MoveBullet()
        {
            transform.position = Vector2.MoveTowards(transform.position, _destination, speed * Time.deltaTime);
        }
    }
}