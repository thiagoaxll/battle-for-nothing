using UnityEngine;

namespace Interactables
{
    public class Platform : MonoBehaviour
    {

        [Header("SETTINGS"), Space(10)]
        public float platformSpeed;
        public GameObject platform;
        public GameObject[] destinationPositions;
        
        private int _nextPlatformIndex;
        private bool _platformGoing;
        private void Update()
        {
            CheckNextPlatformToMove();
            MovePlatform();
        }

        private void CheckNextPlatformToMove()
        {
            if (platform.transform.position == destinationPositions[_nextPlatformIndex].transform.position)
            {
                if (_nextPlatformIndex == destinationPositions.Length - 1) 
                    _platformGoing = false;

                else if (_nextPlatformIndex == 0)
                    _platformGoing = true;
                
                _nextPlatformIndex += _platformGoing ? 1 : -1;
            }
        }
        private void MovePlatform()
        {
            platform.transform.position =
                Vector2.MoveTowards(platform.transform.position,
                    destinationPositions[_nextPlatformIndex].transform.position,
                    platformSpeed * Time.deltaTime);
        }

    }
}