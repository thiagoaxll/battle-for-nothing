using System;
using UnityEngine;

namespace CustomSystem
{
    public class NavigationController : LegacyInputImplementation
    {
        public static NavigationController instance;
        public INavigationSystem currentNavigationSystem;
        public GameObject[] menus;
        public Menus currentMenu;

        public int currentNavigationX;
        public int currentNavigationY;
        public int maxNavigationX;
        public int maxNavigationY;

        private float _delayToChangeDirection = 0.18f;
        private float _auxDelayToChangeDirection;
        
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            SetJoystick(JoystickIndex.JoystickOne);
        }

        private void Update()
        {
            ChangeSelectedOption(ButtonDirection().x, ButtonDirection().y);
            if (ButtonA())
            {
                currentNavigationSystem.OnConfirm();
            }
            else if (ButtonB())
            {
                currentNavigationSystem.OnCancel();
            }
        }

        private void ChangeSelectedOption(float x, float y)
        {
            float analogStickDeadZone = 0.1f;
            _auxDelayToChangeDirection += Time.deltaTime;
            if(Math.Abs(x) < analogStickDeadZone && Math.Abs(y) < analogStickDeadZone) return;
            if (_auxDelayToChangeDirection >= _delayToChangeDirection)
            {
                _auxDelayToChangeDirection = 0;
                CheckJoystickDirection(x, y);
            }
        }

        private void CheckJoystickDirection(float x, float y)
        {
            if (Math.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    currentNavigationSystem.OnRight();
                }
                else
                {
                    currentNavigationSystem.OnLeft();
                }
            }
            else
            {
                if (y > 0)
                {
                    currentNavigationSystem.OnUp();
                }
                else
                {
                    currentNavigationSystem.OnDown();
                }
            }
            currentNavigationSystem.OnUpdateHud();
        }

        private void SetCurrentMenu(int index)
        {
            foreach (var temp in menus)
            {
                temp.SetActive(false);
            }
            menus[index].SetActive(true);
            currentNavigationX = 0;
            currentNavigationY = 0;
        }

        public void ChangeMenu(Menus menu)
        {
            currentMenu = menu;
            foreach (var temp in this.menus)
            {
                temp.SetActive(false);
            }
            menus[(int) menu].SetActive(true);
        }
    }

    public interface INavigationSystem
    {
        void OnUpdateHud();
        void OnConfirm();
        void OnCancel();
        void OnLeft();
        void OnRight();
        void OnUp();
        void OnDown();
    }
    
    public enum Menus
    {
        MainMenu,
        Settings,
        CharacterSelection
    }
}