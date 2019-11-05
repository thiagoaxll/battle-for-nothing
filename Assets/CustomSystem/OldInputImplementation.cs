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

        protected virtual bool ButtonA(bool holdButton = false)
        {
            return holdButton ?
                Input.GetButtonDown(joystickNumber + "ButtonA") : Input.GetButton(joystickNumber + "ButtonA");
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