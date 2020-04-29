using UnityEngine.UI;
using UnityEngine;

namespace CustomSystem.Menu
{
    public class MenuOne : MonoBehaviour, INavigationSystem
    {
        [SerializeField] private int menuIndex;
        [SerializeField] private int menuIndexMax;
        public Button[] buttons;

        private void Awake()
        {
            NavigationController.instance.currentNavigationSystem = this;
        }

        private void Start()
        {
            menuIndexMax = buttons.Length;
        }

        public void SelectCharacterMenu()
        {
            MainMenuManager.instance.RandomCharacters();
            MainMenuManager.currentMenu = MainMenuManager.CurrentMenu.CharacterSelect;
            MainMenuManager.instance.ChangeMenu();
        }

        private bool CheckOptionsIndex(bool moveUp)
        {
            if (moveUp)
            {
                return menuIndex < menuIndexMax - 1;
            }
            else
            {
                return menuIndex > 0;
            }
        }
        
        public void OnUpdateHud()
        {
            switch (menuIndex)
            {
                case 0:
                    print("START");
                    break;
                case 1:
                    print("SETTINGS");
                    break;
                case 2:
                    print("QUIT");
                    break;
            }
        }

        public void OnConfirm()
        {
        }

        public void OnCancel()
        {
        }

        public void OnLeft()
        {
        }

        public void OnRight()
        {
        }

        public void OnUp()
        {
            if (CheckOptionsIndex(true))
            {
                menuIndex++;
            }
        }

        public void OnDown()
        {
            if (CheckOptionsIndex(false))
            {
                menuIndex--;
            }
        }
    }
}