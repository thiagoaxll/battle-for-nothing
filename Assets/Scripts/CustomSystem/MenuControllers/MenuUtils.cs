namespace CustomSystem.MenuControllers
{
    public class MenuUtils
    {

        public int ReturnBoundaryIndex(int currentIndex, int maxIndex, MenuDirection direction)
        {
            if (direction == MenuDirection.Up || direction == MenuDirection.Left)
            {
                if (currentIndex > 0) return --currentIndex;
            }
            else
            {
                if (currentIndex < maxIndex - 1) return ++currentIndex;
            }
            return currentIndex;
        }
    }

    public enum MenuDirection
    {
        Up,
        Down,
        Right,
        Left
    }
}