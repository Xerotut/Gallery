// GENERATED AUTOMATICALLY FROM 'Assets/New Controls.inputactions'

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
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""PhoneActions"",
            ""id"": ""b26779a1-6635-442b-986f-ab3eacd2f6d5"",
            ""actions"": [
                {
                    ""name"": ""OnAttitudeChange"",
                    ""type"": ""Value"",
                    ""id"": ""1c52de23-bb78-4fda-8c02-e52354ff0d2b"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0b13f0f8-f6c3-418c-a689-c1da40abec97"",
                    ""path"": ""<AttitudeSensor>/attitude"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnAttitudeChange"",
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
        m_PhoneActions_OnAttitudeChange = m_PhoneActions.FindAction("OnAttitudeChange", throwIfNotFound: true);
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
    private readonly InputAction m_PhoneActions_OnAttitudeChange;
    public struct PhoneActionsActions
    {
        private @PhoneControls m_Wrapper;
        public PhoneActionsActions(@PhoneControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnAttitudeChange => m_Wrapper.m_PhoneActions_OnAttitudeChange;
        public InputActionMap Get() { return m_Wrapper.m_PhoneActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PhoneActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPhoneActionsActions instance)
        {
            if (m_Wrapper.m_PhoneActionsActionsCallbackInterface != null)
            {
                @OnAttitudeChange.started -= m_Wrapper.m_PhoneActionsActionsCallbackInterface.OnOnAttitudeChange;
                @OnAttitudeChange.performed -= m_Wrapper.m_PhoneActionsActionsCallbackInterface.OnOnAttitudeChange;
                @OnAttitudeChange.canceled -= m_Wrapper.m_PhoneActionsActionsCallbackInterface.OnOnAttitudeChange;
            }
            m_Wrapper.m_PhoneActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OnAttitudeChange.started += instance.OnOnAttitudeChange;
                @OnAttitudeChange.performed += instance.OnOnAttitudeChange;
                @OnAttitudeChange.canceled += instance.OnOnAttitudeChange;
            }
        }
    }
    public PhoneActionsActions @PhoneActions => new PhoneActionsActions(this);
    public interface IPhoneActionsActions
    {
        void OnOnAttitudeChange(InputAction.CallbackContext context);
    }
}
