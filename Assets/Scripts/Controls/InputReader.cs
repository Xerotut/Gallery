using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gallery
{
    public static class InputReader 
    {

        private static PhoneControls _phoneControls;

        public static event Action OnGoBack;

        [RuntimeInitializeOnLoadMethod]
        private static void PrepareInputReading()
        {
            _phoneControls = new PhoneControls();
            SubscribeToInputs();

            _phoneControls.Enable();

        }

        private static void SubscribeToInputs()
        {
            _phoneControls.SystemActions.Back.performed += ctx => OnGoBack?.Invoke(); 
        }

    }
}
