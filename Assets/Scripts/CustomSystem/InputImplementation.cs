using UnityEngine;

namespace CustomSystem
{
    public class InputImplementation : MonoBehaviour
    {
        private MyInput control;


        protected virtual void StartController()
        {
            control = new MyInput();
            control.Enable();
            SetController();
        }

        protected virtual void StopController()
        {
            control.Disable();
        }

        private void SetController()
        {
            control.Enable();
            control.XboxController.ButtonA.performed += context => ButtonA();
            control.XboxController.ButtonB.performed += context => ButtonB();
            control.XboxController.ButtonX.performed += context => ButtonX();
            control.XboxController.ButtonY.performed += context => ButtonY();

            control.XboxController.ButtonMenu.performed += context => ButtonMenu();
            control.XboxController.ButtonView.performed += context => ButtonView();

            control.XboxController.ButtonLb.performed += context => ButtonLb();
            control.XboxController.ButtonLt.performed += context => ButtonLt();
            control.XboxController.ButtonL3.performed += context => ButtonL3();

            control.XboxController.ButtonRb.performed += context => ButtonRb();
            control.XboxController.ButtonRt.performed += context => ButtonRt();
            control.XboxController.ButtonR3.performed += context => ButtonR3();

            control.XboxController.ButtonDpadUp.performed += context => ButtonDpadUp();
            control.XboxController.ButtonDpadDown.performed += context => ButtonDpadDown();
            control.XboxController.ButtonDpadLeft.performed += context => ButtonDpadLeft();
            control.XboxController.ButtonDpadRight.performed += context => ButtonDpadRight();
        }


        protected virtual Vector2 ButtonDirection()
        {
            return control.XboxController.ButtonDirection.ReadValue<Vector2>();
        }

        protected virtual Vector2 RightAnalog()
        {
            return control.XboxController.ButtonRightAnalog.ReadValue<Vector2>();
        }

        protected void ButtonDpadUp()
        {
        }

        protected void ButtonDpadDown()
        {
        }

        protected void ButtonDpadLeft()
        {
        }

        protected void ButtonDpadRight()
        {
        }

        protected virtual void ButtonA()
        {
        }

        protected void ButtonB()
        {
        }

        protected void ButtonX()
        {
        }

        protected void ButtonY()
        {
        }

        protected void ButtonMenu()
        {
        }

        protected void ButtonView()
        {
        }

        protected void ButtonLb()
        {
        }

        protected void ButtonLt()
        {
        }

        protected void ButtonL3()
        {
        }

        protected void ButtonRb()
        {
        }

        protected void ButtonRt()
        {
        }

        protected void ButtonR3()
        {
        }
    }
}