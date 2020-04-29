using System;
using UnityEngine;

namespace CustomSystem
{
    public class NavigationController : LegacyInputImplementation
    {
        public static NavigationController instance;
        public INavigationSystem currentNavigationSystem;
        public GameObject[] menus;

        public int currentNavigationX;
        public int currentNavigationY;
        public int maxNavigationX;
        public int maxNavigationY;

        private float _delayToChangeDirection = 0.25f;
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
            float analogStickDeadZone = 0.03f;
            _auxDelayToChangeDirection += Time.deltaTime;
            if(Math.Abs(x) < analogStickDeadZone|| Math.Abs(y) < analogStickDeadZone) return;
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
        
        public void ChangeMenu(int menuIndex, Action action)
        {
            switch (menuIndex)
            {
                case 0:
                    SetCurrentMenu(action == Action.OnConfirm ? 1 : 0);
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
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

    public enum Action
    {
        OnConfirm,
        OnCancel
    }
}