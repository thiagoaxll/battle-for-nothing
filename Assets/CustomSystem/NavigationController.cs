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

        private float _delayToChangeDirection = 0.5f;
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
                currentNavigationSystem.OnConfirm(currentNavigationX, currentNavigationY);
            }
        }

        private void ChangeSelectedOption(float x, float y)
        {
            _auxDelayToChangeDirection += Time.deltaTime;
            if(x == 0 || y == 0) return;;
            if (_auxDelayToChangeDirection >= _delayToChangeDirection)
            {
                _auxDelayToChangeDirection = 0;
            }
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
        
        void OnConfirm(int x, int y);
        void OnCancel();
        Vector2 OnLeft(int x, int y);
        Vector2 OnRight(int x, int y);
        Vector2 OnUp(int x, int y);
        Vector2 OnDown(int x, int y);
    }

    public enum Action
    {
        OnConfirm,
        OnCancel
    }
}