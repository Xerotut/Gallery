// GENERATED AUTOMATICALLY FROM 'Assets/PhoneControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PhoneControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PhoneControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PhoneControls"",
    ""maps"": [
        {
            ""name"": ""SystemActions"",
            ""id"": ""b26779a1-6635-442b-986f-ab3eacd2f6d5"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""a806fb65-7797-4574-b750-ae40ab876d1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FingerContact"",
                    ""type"": ""Button"",
                    ""id"": ""0c49dc4c-f1a1-453c-97da-2b6dc196e287"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FingerPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""46c8ceee-fa3a-44cf-9ca4-356d6c840ace"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8967dc46-de5d-47a1-a6b9-af238e39ffce"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""388d6ae8-7bbe-406e-9d5b-0ed17609f14a"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FingerContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6773eb9-b549-4297-a565-ac1e3c01c99d"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SystemActions
        m_SystemActions = asset.FindActionMap("SystemActions", throwIfNotFound: true);
        m_SystemActions_Back = m_SystemActions.FindAction("Back", throwIfNotFound: true);
        m_SystemActions_FingerContact = m_SystemActions.FindAction("FingerContact", throwIfNotFound: true);
        m_SystemActions_FingerPosition = m_SystemActions.FindAction("FingerPosition", throwIfNotFound: true);
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

    // SystemActions
    private readonly InputActionMap m_SystemActions;
    private ISystemActionsActions m_SystemActionsActionsCallbackInterface;
    private readonly InputAction m_SystemActions_Back;
    private readonly InputAction m_SystemActions_FingerContact;
    private readonly InputAction m_SystemActions_FingerPosition;
    public struct SystemActionsActions
    {
        private @PhoneControls m_Wrapper;
        public SystemActionsActions(@PhoneControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_SystemActions_Back;
        public InputAction @FingerContact => m_Wrapper.m_SystemActions_FingerContact;
        public InputAction @FingerPosition => m_Wrapper.m_SystemActions_FingerPosition;
        public InputActionMap Get() { return m_Wrapper.m_SystemActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SystemActionsActions set) { return set.Get(); }
        public void SetCallbacks(ISystemActionsActions instance)
        {
            if (m_Wrapper.m_SystemActionsActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_SystemActionsActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_SystemActionsActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_SystemActionsActionsCallbackInterface.OnBack;
                @FingerContact.started -= m_Wrapper.m_SystemActionsActionsCallbackInterface.OnFingerContact;
                @FingerContact.performed -= m_Wrapper.m_SystemActionsActionsCallbackInterface.OnFingerContact;
                @FingerContact.canceled -= m_Wrapper.m_SystemActionsActionsCallbackInterface.OnFingerContact;
                @FingerPosition.started -= m_Wrapper.m_SystemActionsActionsCallbackInterface.OnFingerPosition;
                @FingerPosition.performed -= m_Wrapper.m_SystemActionsActionsCallbackInterface.OnFingerPosition;
                @FingerPosition.canceled -= m_Wrapper.m_SystemActionsActionsCallbackInterface.OnFingerPosition;
            }
            m_Wrapper.m_SystemActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @FingerContact.started += instance.OnFingerContact;
                @FingerContact.performed += instance.OnFingerContact;
                @FingerContact.canceled += instance.OnFingerContact;
                @FingerPosition.started += instance.OnFingerPosition;
                @FingerPosition.performed += instance.OnFingerPosition;
                @FingerPosition.canceled += instance.OnFingerPosition;
            }
        }
    }
    public SystemActionsActions @SystemActions => new SystemActionsActions(this);
    public interface ISystemActionsActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnFingerContact(InputAction.CallbackContext context);
        void OnFingerPosition(InputAction.CallbackContext context);
    }
}
