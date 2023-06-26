using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gallery
{
    public static class InputReader
    {
        private static PhoneControls _controls;


        public static event Action<Quaternion> OnTurn;

        [RuntimeInitializeOnLoadMethod]
        private static void PrepareInputReading()
        {
            _controls = new PhoneControls();
            SubscribeToInputs();

            _controls.Enable();
        }

        private static void SubscribeToInputs()
        {
            if (AttitudeSensor.current != null)
            {
                _controls.PhoneActions.OnAttitudeChange.performed += ctx => OnTurn?.Invoke(ctx.ReadValue<Quaternion>());
            }
        }

    }
}
