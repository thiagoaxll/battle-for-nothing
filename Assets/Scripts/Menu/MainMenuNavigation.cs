using System;
using UnityEngine;

namespace Menu
{
    public class MainMenuNavigation : MonoBehaviour, INavigationCommands
    {
        public static MainMenuNavigation instance;
        public INavigationCommands mainNavigationCommands;
        public int optionsQuantity;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            
            mainNavigationCommands = this;
        }

        public void Execute(Vector2 coordinates)
        {
            switch (coordinates.x)
            {
                case 0:
                    print("CASE 0");
                    break;
                case 1:
                    print("CASE 1");
                    break;
                case 2:
                    print("CASE 2");
                    break;
            }
        }

        public void Back()
        {
            throw new System.NotImplementedException();
        }

        public void MoveUp()
        {
            throw new System.NotImplementedException();
        }

        public void MoveDown()
        {
            throw new System.NotImplementedException();
        }

        public void MoveLef()
        {
            throw new System.NotImplementedException();
        }

        public void MoveRight()
        {
            throw new System.NotImplementedException();
        }
    }
}
