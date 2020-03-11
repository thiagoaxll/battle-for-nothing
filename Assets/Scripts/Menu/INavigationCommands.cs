using UnityEngine;

namespace Menu
{
    public interface INavigationCommands
    {
        void Execute(Vector2 coordinates);
        void Back();
        void MoveUp();
        void MoveDown();
        void MoveLef();
        void MoveRight();
    }
}