// GENERATED AUTOMATICALLY FROM 'Assets/System/MyInput.inputactions'

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
            ""name"": ""MY_CONTROL"",
            ""id"": ""d143eb5e-d98f-4d69-832c-df556e311a03"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""abc111dd-1bfd-4f2c-932f-9451aaa116b0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D_PAD"",
                    ""type"": ""Button"",
                    ""id"": ""906d7a4d-46a1-452d-81e5-7a6e0540bfa6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LEFT"",
                    ""type"": ""Button"",
                    ""id"": ""8008acb0-fca8-4e09-b4b8-996fb52f7f71"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RIGHT"",
                    ""type"": ""Button"",
                    ""id"": ""0cbefdca-29eb-4643-9c56-dcd5aa3de0ba"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e439e61f-271e-473e-acc7-b9cdda3d6378"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""default"",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f8c5efaf-57fe-4c9b-b4b7-f32441cf2c60"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D_PAD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fed6de2e-1a89-44ac-b8e8-1e39d06781bc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""default"",
                    ""action"": ""D_PAD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bbd02c28-bd56-4402-9484-0857ffdc4498"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D_PAD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a7d0fff4-8aa2-4456-b8ca-ae6cafb208a8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""default"",
                    ""action"": ""D_PAD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fd844836-8a9d-4350-83fb-4446b8053604"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""default"",
                    ""action"": ""D_PAD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1a4f8c01-be0d-4016-9293-b8f9de541170"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LEFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8535b96a-92b8-4b25-92cf-935c2dda26b9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RIGHT"",
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
        // MY_CONTROL
        m_MY_CONTROL = asset.FindActionMap("MY_CONTROL", throwIfNotFound: true);
        m_MY_CONTROL_A = m_MY_CONTROL.FindAction("A", throwIfNotFound: true);
        m_MY_CONTROL_D_PAD = m_MY_CONTROL.FindAction("D_PAD", throwIfNotFound: true);
        m_MY_CONTROL_LEFT = m_MY_CONTROL.FindAction("LEFT", throwIfNotFound: true);
        m_MY_CONTROL_RIGHT = m_MY_CONTROL.FindAction("RIGHT", throwIfNotFound: true);
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

    // MY_CONTROL
    private readonly InputActionMap m_MY_CONTROL;
    private IMY_CONTROLActions m_MY_CONTROLActionsCallbackInterface;
    private readonly InputAction m_MY_CONTROL_A;
    private readonly InputAction m_MY_CONTROL_D_PAD;
    private readonly InputAction m_MY_CONTROL_LEFT;
    private readonly InputAction m_MY_CONTROL_RIGHT;
    public struct MY_CONTROLActions
    {
        private MyInput m_Wrapper;
        public MY_CONTROLActions(MyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_MY_CONTROL_A;
        public InputAction @D_PAD => m_Wrapper.m_MY_CONTROL_D_PAD;
        public InputAction @LEFT => m_Wrapper.m_MY_CONTROL_LEFT;
        public InputAction @RIGHT => m_Wrapper.m_MY_CONTROL_RIGHT;
        public InputActionMap Get() { return m_Wrapper.m_MY_CONTROL; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MY_CONTROLActions set) { return set.Get(); }
        public void SetCallbacks(IMY_CONTROLActions instance)
        {
            if (m_Wrapper.m_MY_CONTROLActionsCallbackInterface != null)
            {
                A.started -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnA;
                A.performed -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnA;
                A.canceled -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnA;
                D_PAD.started -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnD_PAD;
                D_PAD.performed -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnD_PAD;
                D_PAD.canceled -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnD_PAD;
                LEFT.started -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnLEFT;
                LEFT.performed -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnLEFT;
                LEFT.canceled -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnLEFT;
                RIGHT.started -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnRIGHT;
                RIGHT.performed -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnRIGHT;
                RIGHT.canceled -= m_Wrapper.m_MY_CONTROLActionsCallbackInterface.OnRIGHT;
            }
            m_Wrapper.m_MY_CONTROLActionsCallbackInterface = instance;
            if (instance != null)
            {
                A.started += instance.OnA;
                A.performed += instance.OnA;
                A.canceled += instance.OnA;
                D_PAD.started += instance.OnD_PAD;
                D_PAD.performed += instance.OnD_PAD;
                D_PAD.canceled += instance.OnD_PAD;
                LEFT.started += instance.OnLEFT;
                LEFT.performed += instance.OnLEFT;
                LEFT.canceled += instance.OnLEFT;
                RIGHT.started += instance.OnRIGHT;
                RIGHT.performed += instance.OnRIGHT;
                RIGHT.canceled += instance.OnRIGHT;
            }
        }
    }
    public MY_CONTROLActions @MY_CONTROL => new MY_CONTROLActions(this);
    private int m_defaultSchemeIndex = -1;
    public InputControlScheme defaultScheme
    {
        get
        {
            if (m_defaultSchemeIndex == -1) m_defaultSchemeIndex = asset.FindControlSchemeIndex("default");
            return asset.controlSchemes[m_defaultSchemeIndex];
        }
    }
    public interface IMY_CONTROLActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnD_PAD(InputAction.CallbackContext context);
        void OnLEFT(InputAction.CallbackContext context);
        void OnRIGHT(InputAction.CallbackContext context);
    }
}
