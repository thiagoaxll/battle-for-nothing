using System.Threading.Tasks;
using UnityEngine;
using System;

namespace CustomSystem
{
    public class NavigationController : LegacyInputImplementation
    {
        public INavigationSystem currentNavigationSystem;
        public JoystickIndex joystickIndex;
        private bool _canChangeDirection = true;
        
        private void Awake()
        {
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
            if(Math.Abs(x) < analogStickDeadZone && Math.Abs(y) < analogStickDeadZone) return;
            if (_canChangeDirection)
            {
                CheckJoystickDirection(x, y);
                new Task (async () =>
                {
                    _canChangeDirection = false;
                    await Task.Delay(150);
                    _canChangeDirection = true;
                }).Start();
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
                    currentNavigationSystem.OnDown();
                }
                else
                {
                    currentNavigationSystem.OnUp();
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