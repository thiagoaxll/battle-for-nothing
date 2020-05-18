using UnityEngine;

namespace CustomSystem.MenuControllers
{
    public class MenuUtils
    {

        public int ReturnBoundaryIndex(int currentIndex, int maxIndex, MenuDirection direction)
        {
            Debug.Log("D" + direction);
            if (direction == MenuDirection.Up)
            {
                if (currentIndex < maxIndex - 1) return ++currentIndex;
            }
            else
            {
                if (currentIndex > 0) return --currentIndex;
            }
            return currentIndex;
        }
    }

    public enum MenuDirection
    {
        Up,
        Down
    }
}