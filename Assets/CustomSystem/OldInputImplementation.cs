using UnityEngine;

namespace CustomSystem
{
    public class OldInputImplementation : MonoBehaviour
    {
        public string joystickNumber;

        protected void SetJoystick(JoystickIndex joystickIndex)
        {
            switch (joystickIndex)
            {
                case JoystickIndex.JoystickOne:
                    joystickNumber = "J1";
                    break;
                case JoystickIndex.JoystickTwo:
                    joystickNumber = "J2";
                    break;
                case JoystickIndex.JoystickThree:
                    joystickNumber = "J3";
                    break;
                case JoystickIndex.JoystickFour:
                    joystickNumber = "J4";
                    break;
                default:
                    joystickNumber = "J1";
                    break;
            }
        }

        protected virtual Vector2 ButtonDirection()
        {
            var direction = new Vector2
            {
                x = Input.GetAxisRaw(joystickNumber + "Horizontal"),
                y = Input.GetAxisRaw(joystickNumber + "Vertical")
            };
            return direction;
        }

        protected virtual Vector2 RightAnalog()
        {
            var direction = new Vector2
            {
                x = Input.GetAxisRaw(joystickNumber + "ButtonRightHorizontal"),
                y = Input.GetAxisRaw(joystickNumber + "ButtonRightVertical")
            };
            return direction;
        }

        protected virtual bool ButtonA(bool holdButton = false)
        {
            return holdButton
                ? Input.GetButton(joystickNumber + "ButtonA")
                : Input.GetButtonDown(joystickNumber + "ButtonA");
        }

        protected virtual bool ButtonX(bool holdButton = false)
        {
            return holdButton
                ? Input.GetButton(joystickNumber + "ButtonX")
                : Input.GetButtonDown(joystickNumber + "ButtonX");
        }
        protected virtual bool ButtonY(bool holdButton = false)
        {
            return holdButton
                ? Input.GetButton(joystickNumber + "ButtonY")
                : Input.GetButtonDown(joystickNumber + "ButtonY");
        }
        
        protected virtual bool ButtonB(bool holdButton = false)
        {
            return holdButton
                ? Input.GetButton(joystickNumber + "ButtonB")
                : Input.GetButtonDown(joystickNumber + "ButtonB");
        }

        protected virtual bool ButtonLb(bool holdButton = false)
        {
            return holdButton
                ? Input.GetButton(joystickNumber + "ButtonLb")
                : Input.GetButtonDown(joystickNumber + "ButtonLb");
        }

        protected virtual bool ButtonRb(bool holdButton = false)
        {
            return holdButton
                ? Input.GetButton(joystickNumber + "ButtonRb")
                : Input.GetButtonDown(joystickNumber + "ButtonRb");
        }
    }

    public enum JoystickIndex
    {
        JoystickOne,
        JoystickTwo,
        JoystickThree,
        JoystickFour
    }
}