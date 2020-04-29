// GENERATED AUTOMATICALLY FROM 'Assets/CustomSystem/MyInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class MyInput : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public MyInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInput"",
    ""maps"": [
        {
            ""name"": ""XboxController"",
            ""id"": ""d143eb5e-d98f-4d69-832c-df556e311a03"",
            ""actions"": [
                {
                    ""name"": ""ButtonDirection"",
                    ""type"": ""Value"",
                    ""id"": ""906d7a4d-46a1-452d-81e5-7a6e0540bfa6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonLeftAnalog"",
                    ""type"": ""Value"",
                    ""id"": ""822e1dc1-c182-4ce7-a89c-89bf26d86b78"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonRightAnalog"",
                    ""type"": ""Value"",
                    ""id"": ""2c0d281a-0ffb-46f8-a681-ab20d2d3e550"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonDpadUp"",
                    ""type"": ""Button"",
                    ""id"": ""f27a1a4d-861c-4943-834c-9d47bce357ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonDpadDown"",
                    ""type"": ""Button"",
                    ""id"": ""8443e2da-f8ae-4a02-946c-3a79ebc893d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonDpadLeft"",
                    ""type"": ""Button"",
                    ""id"": ""ecf247f2-6e1e-4791-9aa7-35b16248e3dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonDpadRight"",
                    ""type"": ""Button"",
                    ""id"": ""664b0ddf-d9c9-4cc4-acaa-3f62dab57743"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonA"",
                    ""type"": ""Button"",
                    ""id"": ""abc111dd-1bfd-4f2c-932f-9451aaa116b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonB"",
                    ""type"": ""Button"",
                    ""id"": ""b1b597a4-b03d-4f8c-9402-6be3d0b6b696"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonY"",
                    ""type"": ""Button"",
                    ""id"": ""9a2df1fd-c7b6-4fb2-991e-ee01230372c6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonX"",
                    ""type"": ""Button"",
                    ""id"": ""8f8e184d-51ad-4cf4-93d4-2f970d9fea5e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonMenu"",
                    ""type"": ""Button"",
                    ""id"": ""2e3679b0-2d60-4cf7-bb32-3b42309092a4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonView"",
                    ""type"": ""Button"",
                    ""id"": ""6df2be72-1613-44e0-b9dd-a8b98ca5d0d0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonLb"",
                    ""type"": ""Button"",
                    ""id"": ""64ad7c15-4108-445a-9bb2-168def41c049"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonLt"",
                    ""type"": ""Button"",
                    ""id"": ""e3fd1d4f-461b-48a3-9c55-0e1a8a27408d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonL3"",
                    ""type"": ""Button"",
                    ""id"": ""de64145e-c66b-4212-af19-081ec0ede728"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonRb"",
                    ""type"": ""Button"",
                    ""id"": ""fbf7ba50-0503-4f6e-980d-2875e2cdfb25"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonRt"",
                    ""type"": ""Button"",
                    ""id"": ""3c291e3d-35a5-443a-bc98-be292568419f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonR3"",
                    ""type"": ""Button"",
                    ""id"": ""2e9f3b76-7136-44b9-a101-7a24579315f7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5347df29-24e2-479f-af48-addcdeedf4c6"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ButtonLeftAnalog"",
                    ""id"": ""1b9a939b-aab0-45d4-a7ef-1bea59ac9ec6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ee1e1ae1-c337-48a3-9a30-f30f03519feb"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5f0eae4f-ce67-469c-b81f-c16d69cb94ab"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2622b342-b89b-424c-845d-8fed719fea80"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""22ad4345-6c26-4898-8dec-aedec1747dd2"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ButtonDpad"",
                    ""id"": ""00781022-ed5b-4593-a70c-22d0289faf6e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dc878812-c099-4cc7-bc50-7e9982ad276b"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ad0ece32-cc0b-4225-99be-be4ff4f513f9"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c0a27286-8523-4837-a037-55a1711f64f4"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a50b9662-523a-49d6-99ec-685b33c77d04"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c221df94-4692-446e-8e27-d5ec8bd45faa"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b5e75a5-6f2c-4af1-a05b-d285fbd6e227"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be69ca23-42ff-403c-b93f-3c4f853ed5c2"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4158cb2e-dd14-4fb8-a8a2-858505b9483e"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13103c09-54a1-41b3-960c-9f1c413438fb"",
                    ""path"": ""<XInputController>/select"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f0c9cce-32de-4b67-b66c-010c2be8710c"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonLb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f65704e-f731-43aa-82c6-816decfcf7bb"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonLt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8363a441-5e3f-47f7-a375-bd26804e5e45"",
                    ""path"": ""<XInputController>/leftStickPress"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonL3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e84b7ca7-4694-44b4-9b48-d430ce54fc28"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonRb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""629b8193-a399-468c-b945-0f48607285a2"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonRt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0683b35-f4b4-4715-b91b-9009fe487ff7"",
                    ""path"": ""<XInputController>/rightStickPress"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonR3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ButtonLeftAnalog"",
                    ""id"": ""6c119745-eb08-4906-aa0a-4a6822e5514a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonLeftAnalog"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""71bf135e-57ae-47a7-8885-e7c2f8bb8f68"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonLeftAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eb335b28-2e94-4514-b7f9-75a217d27ef5"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonLeftAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""62cae929-4060-4338-97c7-9fc1556e82d5"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonLeftAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a1cfeb53-29fd-4fa9-9dac-f39c002c90ec"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonLeftAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ButtonRightAnalog"",
                    ""id"": ""6f0bf3ba-bf02-4882-ab51-9bbcb706a720"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonRightAnalog"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4a301075-3e93-4052-8721-1ea18b5b193b"",
                    ""path"": ""<XInputController>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonRightAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ac9e7327-7b55-4c8b-bec5-2c6bb1bfb901"",
                    ""path"": ""<XInputController>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonRightAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""00c4f93d-7326-471f-919e-38a4f49f4106"",
                    ""path"": ""<XInputController>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonRightAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4ae5043d-a0a2-41ad-8c7e-c02171796a02"",
                    ""path"": ""<XInputController>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonRightAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""be32e980-c3bf-400b-9a5b-5b6f889510d4"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDpadUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4b212e7-9672-4638-8e60-b7d9d28659cd"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDpadDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5f77e44-2eb5-4d30-a071-b505b7c0896e"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDpadLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ec06b82-de10-4e81-9e7f-4098eec3f8e7"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDpadRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""default"",
            ""bindingGroup"": ""default"",
            ""devices"": []
        }
    ]
}");
        // XboxController
        m_XboxController = asset.FindActionMap("XboxController", throwIfNotFound: true);
        m_XboxController_ButtonDirection = m_XboxController.FindAction("ButtonDirection", throwIfNotFound: true);
        m_XboxController_ButtonLeftAnalog = m_XboxController.FindAction("ButtonLeftAnalog", throwIfNotFound: true);
        m_XboxController_ButtonRightAnalog = m_XboxController.FindAction("ButtonRightAnalog", throwIfNotFound: true);
        m_XboxController_ButtonDpadUp = m_XboxController.FindAction("ButtonDpadUp", throwIfNotFound: true);
        m_XboxController_ButtonDpadDown = m_XboxController.FindAction("ButtonDpadDown", throwIfNotFound: true);
        m_XboxController_ButtonDpadLeft = m_XboxController.FindAction("ButtonDpadLeft", throwIfNotFound: true);
        m_XboxController_ButtonDpadRight = m_XboxController.FindAction("ButtonDpadRight", throwIfNotFound: true);
        m_XboxController_ButtonA = m_XboxController.FindAction("ButtonA", throwIfNotFound: true);
        m_XboxController_ButtonB = m_XboxController.FindAction("ButtonB", throwIfNotFound: true);
        m_XboxController_ButtonY = m_XboxController.FindAction("ButtonY", throwIfNotFound: true);
        m_XboxController_ButtonX = m_XboxController.FindAction("ButtonX", throwIfNotFound: true);
        m_XboxController_ButtonMenu = m_XboxController.FindAction("ButtonMenu", throwIfNotFound: true);
        m_XboxController_ButtonView = m_XboxController.FindAction("ButtonView", throwIfNotFound: true);
        m_XboxController_ButtonLb = m_XboxController.FindAction("ButtonLb", throwIfNotFound: true);
        m_XboxController_ButtonLt = m_XboxController.FindAction("ButtonLt", throwIfNotFound: true);
        m_XboxController_ButtonL3 = m_XboxController.FindAction("ButtonL3", throwIfNotFound: true);
        m_XboxController_ButtonRb = m_XboxController.FindAction("ButtonRb", throwIfNotFound: true);
        m_XboxController_ButtonRt = m_XboxController.FindAction("ButtonRt", throwIfNotFound: true);
        m_XboxController_ButtonR3 = m_XboxController.FindAction("ButtonR3", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // XboxController
    private readonly InputActionMap m_XboxController;
    private IXboxControllerActions m_XboxControllerActionsCallbackInterface;
    private readonly InputAction m_XboxController_ButtonDirection;
    private readonly InputAction m_XboxController_ButtonLeftAnalog;
    private readonly InputAction m_XboxController_ButtonRightAnalog;
    private readonly InputAction m_XboxController_ButtonDpadUp;
    private readonly InputAction m_XboxController_ButtonDpadDown;
    private readonly InputAction m_XboxController_ButtonDpadLeft;
    private readonly InputAction m_XboxController_ButtonDpadRight;
    private readonly InputAction m_XboxController_ButtonA;
    private readonly InputAction m_XboxController_ButtonB;
    private readonly InputAction m_XboxController_ButtonY;
    private readonly InputAction m_XboxController_ButtonX;
    private readonly InputAction m_XboxController_ButtonMenu;
    private readonly InputAction m_XboxController_ButtonView;
    private readonly InputAction m_XboxController_ButtonLb;
    private readonly InputAction m_XboxController_ButtonLt;
    private readonly InputAction m_XboxController_ButtonL3;
    private readonly InputAction m_XboxController_ButtonRb;
    private readonly InputAction m_XboxController_ButtonRt;
    private readonly InputAction m_XboxController_ButtonR3;
    public struct XboxControllerActions
    {
        private MyInput m_Wrapper;
        public XboxControllerActions(MyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ButtonDirection => m_Wrapper.m_XboxController_ButtonDirection;
        public InputAction @ButtonLeftAnalog => m_Wrapper.m_XboxController_ButtonLeftAnalog;
        public InputAction @ButtonRightAnalog => m_Wrapper.m_XboxController_ButtonRightAnalog;
        public InputAction @ButtonDpadUp => m_Wrapper.m_XboxController_ButtonDpadUp;
        public InputAction @ButtonDpadDown => m_Wrapper.m_XboxController_ButtonDpadDown;
        public InputAction @ButtonDpadLeft => m_Wrapper.m_XboxController_ButtonDpadLeft;
        public InputAction @ButtonDpadRight => m_Wrapper.m_XboxController_ButtonDpadRight;
        public InputAction @ButtonA => m_Wrapper.m_XboxController_ButtonA;
        public InputAction @ButtonB => m_Wrapper.m_XboxController_ButtonB;
        public InputAction @ButtonY => m_Wrapper.m_XboxController_ButtonY;
        public InputAction @ButtonX => m_Wrapper.m_XboxController_ButtonX;
        public InputAction @ButtonMenu => m_Wrapper.m_XboxController_ButtonMenu;
        public InputAction @ButtonView => m_Wrapper.m_XboxController_ButtonView;
        public InputAction @ButtonLb => m_Wrapper.m_XboxController_ButtonLb;
        public InputAction @ButtonLt => m_Wrapper.m_XboxController_ButtonLt;
        public InputAction @ButtonL3 => m_Wrapper.m_XboxController_ButtonL3;
        public InputAction @ButtonRb => m_Wrapper.m_XboxController_ButtonRb;
        public InputAction @ButtonRt => m_Wrapper.m_XboxController_ButtonRt;
        public InputAction @ButtonR3 => m_Wrapper.m_XboxController_ButtonR3;
        public InputActionMap Get() { return m_Wrapper.m_XboxController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XboxControllerActions set) { return set.Get(); }
        public void SetCallbacks(IXboxControllerActions instance)
        {
            if (m_Wrapper.m_XboxControllerActionsCallbackInterface != null)
            {
                ButtonDirection.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDirection;
                ButtonDirection.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDirection;
                ButtonDirection.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDirection;
                ButtonLeftAnalog.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonLeftAnalog;
                ButtonLeftAnalog.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonLeftAnalog;
                ButtonLeftAnalog.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonLeftAnalog;
                ButtonRightAnalog.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonRightAnalog;
                ButtonRightAnalog.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonRightAnalog;
                ButtonRightAnalog.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonRightAnalog;
                ButtonDpadUp.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadUp;
                ButtonDpadUp.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadUp;
                ButtonDpadUp.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadUp;
                ButtonDpadDown.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadDown;
                ButtonDpadDown.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadDown;
                ButtonDpadDown.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadDown;
                ButtonDpadLeft.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadLeft;
                ButtonDpadLeft.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadLeft;
                ButtonDpadLeft.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadLeft;
                ButtonDpadRight.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadRight;
                ButtonDpadRight.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadRight;
                ButtonDpadRight.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonDpadRight;
                ButtonA.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonA;
                ButtonA.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonA;
                ButtonA.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonA;
                ButtonB.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonB;
                ButtonB.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonB;
                ButtonB.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonB;
                ButtonY.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonY;
                ButtonY.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonY;
                ButtonY.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonY;
                ButtonX.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonX;
                ButtonX.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonX;
                ButtonX.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonX;
                ButtonMenu.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonMenu;
                ButtonMenu.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonMenu;
                ButtonMenu.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonMenu;
                ButtonView.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonView;
                ButtonView.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonView;
                ButtonView.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonView;
                ButtonLb.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonLb;
                ButtonLb.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonLb;
                ButtonLb.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonLb;
                ButtonLt.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonLt;
                ButtonLt.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonLt;
                ButtonLt.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonLt;
                ButtonL3.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonL3;
                ButtonL3.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonL3;
                ButtonL3.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonL3;
                ButtonRb.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonRb;
                ButtonRb.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonRb;
                ButtonRb.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonRb;
                ButtonRt.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonRt;
                ButtonRt.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonRt;
                ButtonRt.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonRt;
                ButtonR3.started -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonR3;
                ButtonR3.performed -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonR3;
                ButtonR3.canceled -= m_Wrapper.m_XboxControllerActionsCallbackInterface.OnButtonR3;
            }
            m_Wrapper.m_XboxControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                ButtonDirection.started += instance.OnButtonDirection;
                ButtonDirection.performed += instance.OnButtonDirection;
                ButtonDirection.canceled += instance.OnButtonDirection;
                ButtonLeftAnalog.started += instance.OnButtonLeftAnalog;
                ButtonLeftAnalog.performed += instance.OnButtonLeftAnalog;
                ButtonLeftAnalog.canceled += instance.OnButtonLeftAnalog;
                ButtonRightAnalog.started += instance.OnButtonRightAnalog;
                ButtonRightAnalog.performed += instance.OnButtonRightAnalog;
                ButtonRightAnalog.canceled += instance.OnButtonRightAnalog;
                ButtonDpadUp.started += instance.OnButtonDpadUp;
                ButtonDpadUp.performed += instance.OnButtonDpadUp;
                ButtonDpadUp.canceled += instance.OnButtonDpadUp;
                ButtonDpadDown.started += instance.OnButtonDpadDown;
                ButtonDpadDown.performed += instance.OnButtonDpadDown;
                ButtonDpadDown.canceled += instance.OnButtonDpadDown;
                ButtonDpadLeft.started += instance.OnButtonDpadLeft;
                ButtonDpadLeft.performed += instance.OnButtonDpadLeft;
                ButtonDpadLeft.canceled += instance.OnButtonDpadLeft;
                ButtonDpadRight.started += instance.OnButtonDpadRight;
                ButtonDpadRight.performed += instance.OnButtonDpadRight;
                ButtonDpadRight.canceled += instance.OnButtonDpadRight;
                ButtonA.started += instance.OnButtonA;
                ButtonA.performed += instance.OnButtonA;
                ButtonA.canceled += instance.OnButtonA;
                ButtonB.started += instance.OnButtonB;
                ButtonB.performed += instance.OnButtonB;
                ButtonB.canceled += instance.OnButtonB;
                ButtonY.started += instance.OnButtonY;
                ButtonY.performed += instance.OnButtonY;
                ButtonY.canceled += instance.OnButtonY;
                ButtonX.started += instance.OnButtonX;
                ButtonX.performed += instance.OnButtonX;
                ButtonX.canceled += instance.OnButtonX;
                ButtonMenu.started += instance.OnButtonMenu;
                ButtonMenu.performed += instance.OnButtonMenu;
                ButtonMenu.canceled += instance.OnButtonMenu;
                ButtonView.started += instance.OnButtonView;
                ButtonView.performed += instance.OnButtonView;
                ButtonView.canceled += instance.OnButtonView;
                ButtonLb.started += instance.OnButtonLb;
                ButtonLb.performed += instance.OnButtonLb;
                ButtonLb.canceled += instance.OnButtonLb;
                ButtonLt.started += instance.OnButtonLt;
                ButtonLt.performed += instance.OnButtonLt;
                ButtonLt.canceled += instance.OnButtonLt;
                ButtonL3.started += instance.OnButtonL3;
                ButtonL3.performed += instance.OnButtonL3;
                ButtonL3.canceled += instance.OnButtonL3;
                ButtonRb.started += instance.OnButtonRb;
                ButtonRb.performed += instance.OnButtonRb;
                ButtonRb.canceled += instance.OnButtonRb;
                ButtonRt.started += instance.OnButtonRt;
                ButtonRt.performed += instance.OnButtonRt;
                ButtonRt.canceled += instance.OnButtonRt;
                ButtonR3.started += instance.OnButtonR3;
                ButtonR3.performed += instance.OnButtonR3;
                ButtonR3.canceled += instance.OnButtonR3;
            }
        }
    }
    public XboxControllerActions @XboxController => new XboxControllerActions(this);
    private int m_defaultSchemeIndex = -1;
    public InputControlScheme defaultScheme
    {
        get
        {
            if (m_defaultSchemeIndex == -1) m_defaultSchemeIndex = asset.FindControlSchemeIndex("default");
            return asset.controlSchemes[m_defaultSchemeIndex];
        }
    }
    public interface IXboxControllerActions
    {
        void OnButtonDirection(InputAction.CallbackContext context);
        void OnButtonLeftAnalog(InputAction.CallbackContext context);
        void OnButtonRightAnalog(InputAction.CallbackContext context);
        void OnButtonDpadUp(InputAction.CallbackContext context);
        void OnButtonDpadDown(InputAction.CallbackContext context);
        void OnButtonDpadLeft(InputAction.CallbackContext context);
        void OnButtonDpadRight(InputAction.CallbackContext context);
        void OnButtonA(InputAction.CallbackContext context);
        void OnButtonB(InputAction.CallbackContext context);
        void OnButtonY(InputAction.CallbackContext context);
        void OnButtonX(InputAction.CallbackContext context);
        void OnButtonMenu(InputAction.CallbackContext context);
        void OnButtonView(InputAction.CallbackContext context);
        void OnButtonLb(InputAction.CallbackContext context);
        void OnButtonLt(InputAction.CallbackContext context);
        void OnButtonL3(InputAction.CallbackContext context);
        void OnButtonRb(InputAction.CallbackContext context);
        void OnButtonRt(InputAction.CallbackContext context);
        void OnButtonR3(InputAction.CallbackContext context);
    }
}
