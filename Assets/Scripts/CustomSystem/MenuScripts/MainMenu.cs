using CustomSystem.MenuControllers;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace CustomSystem.MenuScripts
{
    public class MainMenu : MonoBehaviour, INavigationSystem
    {
        [SerializeField] private int menuVerticalIndex;
        [SerializeField] private int menuVerticalIndexMax;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color notSelectedColor;
        public Button[] buttons;

        private void Awake()
        {
            NavigationController.instance.currentNavigationSystem = this;
        }

        private void Start()
        {
            menuVerticalIndexMax = buttons.Length;
            OnUpdateHud();
        }
        
        
        private bool CheckOptionsIndex(bool moveUp)
        {
            if (moveUp)
            {
                return menuVerticalIndex < menuVerticalIndexMax - 1;
            }
            else
            {
                return menuVerticalIndex > 0;
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
            buttons[menuVerticalIndex].GetComponentInChildren<TextMeshProUGUI>().color = selectedColor;
        }

        public void OnConfirm()
        {
            switch (menuVerticalIndex)
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
                menuVerticalIndex++;
            }
        }

        public void OnDown()
        {
            if (CheckOptionsIndex(false))
            {
                menuVerticalIndex--;
            }
        }
    }
}