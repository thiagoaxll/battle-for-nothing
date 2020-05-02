using CustomSystem.MenuControllers;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace CustomSystem.MenuScripts
{
    public class MainMenu : MonoBehaviour, INavigationSystem
    {
        [SerializeField] private int menuIndex;
        [SerializeField] private int menuIndexMax;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color notSelectedColor;
        public Button[] buttons;

        private void Awake()
        {
            NavigationController.instance.currentNavigationSystem = this;
        }

        private void Start()
        {
            menuIndexMax = buttons.Length;
            OnUpdateHud();
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

        private void OnEnable()
        {
            NavigationController.instance.currentNavigationSystem = this;
            OnUpdateHud();
        }

        public void OnUpdateHud()
        {
            foreach (var temp in buttons)
            {
                temp.GetComponentInChildren<TextMeshProUGUI>().color = notSelectedColor;
            }
            buttons[menuIndex].GetComponentInChildren<TextMeshProUGUI>().color = selectedColor;
            
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
            switch (menuIndex)
            {
                case 0:
                    MenuManager.instance.ChangeCurrentMenuRoutine(MenuCatalog.CharacterSelect);
                    break;
                case 1:
                    MenuManager.instance.ChangeCurrentMenuRoutine(MenuCatalog.Settings);
                    break;
                case 2:
                    Application.Quit();
                    break;
            } 
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