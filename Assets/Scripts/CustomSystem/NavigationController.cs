using UnityEngine;
using System;

namespace CustomSystem
{
    public class NavigationController : LegacyInputImplementation
    {
        public static NavigationController instance;
        public INavigationSystem currentNavigationSystem;
        private const float DelayToChangeDirection = 0.18f;
        private float _auxDelayToChangeDirection;
        public JoystickIndex joystickIndex;
        
        private void Awake()
        {
//            if (instance == null)
//            {
//                instance = this;
//            }
//            else
//            {
//                Destroy(gameObject);
//            }
            SetJoystick(joystickIndex);
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
            if (_auxDelayToChangeDirection >= DelayToChangeDirection)
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
}