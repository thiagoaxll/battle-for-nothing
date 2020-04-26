using System;
using UnityEngine;
using CustomSystem;
using UnityEngine.UI;

namespace CustomSystem.Menu
{
    public class MenuOne : MonoBehaviour, INavigationSystem
    {
        [SerializeField] private int menuIndex;
        public Button[] buttons;

        private void Awake()
        {
            NavigationController.instance.currentNavigationSystem = this;
        }

        public void SelectCharacterMenu()
        {
            MainMenuManager.instance.RandomCharacters();
            MainMenuManager.currentMenu = MainMenuManager.CurrentMenu.CharacterSelect;
            MainMenuManager.instance.ChangeMenu();
        }
        
        public void OnConfirm(int x, int y)
        {
            Debug.Log("Confirm menu one");
            switch (y)
            {
                case 0:
                    NavigationController.instance.ChangeMenu(menuIndex, Action.OnConfirm);
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            buttons[y].onClick.Invoke();
        }

        public void OnCancel()
        {
            throw new System.NotImplementedException();
        }

        public Vector2 OnLeft(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public Vector2 OnRight(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public Vector2 OnUp(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public Vector2 OnDown(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}
