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
            ""name"": ""PhoneActions"",
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
                    ""name"": ""TouchInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0c49dc4c-f1a1-453c-97da-2b6dc196e287"",
                    ""expectedControlType"": ""Button"",
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
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PhoneActions
        m_PhoneActions = asset.FindActionMap("PhoneActions", throwIfNotFound: true);
        m_PhoneActions_Back = m_PhoneActions.FindAction("Back", throwIfNotFound: true);
        m_PhoneActions_TouchInput = m_PhoneActions.FindAction("TouchInput", throwIfNotFound: true);
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

    // PhoneActions
    private readonly InputActionMap m_PhoneActions;
    private IPhoneActionsActions m_PhoneActionsActionsCallbackInterface;
    private readonly InputAction m_PhoneActions_Back;
    private readonly InputAction m_PhoneActions_TouchInput;
    public struct PhoneActionsActions
    {
        private @PhoneControls m_Wrapper;
        public PhoneActionsActions(@PhoneControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_PhoneActions_Back;
        public InputAction @TouchInput => m_Wrapper.m_PhoneActions_TouchInput;
        public InputActionMap Get() { return m_Wrapper.m_PhoneActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PhoneActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPhoneActionsActions instance)
        {
            if (m_Wrapper.m_PhoneActionsActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_PhoneActionsActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_PhoneActionsActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_PhoneActionsActionsCallbackInterface.OnBack;
                @TouchInput.started -= m_Wrapper.m_PhoneActionsActionsCallbackInterface.OnTouchInput;
                @TouchInput.performed -= m_Wrapper.m_PhoneActionsActionsCallbackInterface.OnTouchInput;
                @TouchInput.canceled -= m_Wrapper.m_PhoneActionsActionsCallbackInterface.OnTouchInput;
            }
            m_Wrapper.m_PhoneActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @TouchInput.started += instance.OnTouchInput;
                @TouchInput.performed += instance.OnTouchInput;
                @TouchInput.canceled += instance.OnTouchInput;
            }
        }
    }
    public PhoneActionsActions @PhoneActions => new PhoneActionsActions(this);
    public interface IPhoneActionsActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnTouchInput(InputAction.CallbackContext context);
    }
}
