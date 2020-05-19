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
        private NavigationController _navigationController;
        public Button[] buttons;
        private MenuUtils _menuUtils;
        
        private void Start()
        {
            _menuUtils = new MenuUtils();
            _navigationController = gameObject.AddComponent<NavigationController>();
            SetupMainMenu();
        }
        
        private void SetupMainMenu()
        {
            _navigationController.SetJoystick(JoystickIndex.JoystickOne);
            _navigationController.currentNavigationSystem = this;
            menuVerticalIndexMax = buttons.Length;
            OnUpdateHud();
        }
        
        private void OnEnable()
        {
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
            menuVerticalIndex = _menuUtils.ReturnBoundaryIndex(menuVerticalIndex, menuVerticalIndexMax, MenuDirection.Up);
        }

        public void OnDown()
        {
            menuVerticalIndex = _menuUtils.ReturnBoundaryIndex(menuVerticalIndex, menuVerticalIndexMax, MenuDirection.Down);
        }
    }
}