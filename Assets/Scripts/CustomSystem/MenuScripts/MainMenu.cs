using System;
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
            NavigationController.instance.ChangeMenu(Menus.MainMenu);
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
        }

        public int MenuIndex { get; set; } = 0;

        public void OnChangeMenu()
        {
            throw new System.NotImplementedException();
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
                    print("CHARACTER SELECTION **");
                    NavigationController.instance.ChangeMenu(Menus.CharacterSelection);
                    break;
                case 1:
                    print("SETTINGS *|*");
                    NavigationController.instance.ChangeMenu(Menus.Settings);
                    break;
                case 2:
                    print("QUIT **");
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