using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gallery
{
    public static partial class InputReader 
    {

        static InputReader()
        {
            _phoneControls = new PhoneControls();
            SubscribeToInputs();

            _phoneControls.Enable();


        }

        private readonly static PhoneControls _phoneControls;

        public static event Action OnGoBack;

        

        public static event Action<float> OnStartTouch;
        public static event Action<float> OnEndTouch;

        public static event Action OnSwipeRight;
        public static event Action OnSwipeLeft;
        public static event Action OnSwipeUp;
        public static event Action OnSwipeDown;

        private static void SubscribeToInputs()
        {
           
            _phoneControls.SystemActions.FingerContact.started += ctx => OnStartTouch?.Invoke((float)ctx.startTime);
            _phoneControls.SystemActions.FingerContact.started += ctx => OnEndTouch?.Invoke((float)ctx.startTime);

            _phoneControls.SystemActions.Back.performed += ctx => OnGoBack?.Invoke();


            SubscribeToSystemInputs();
        }

        private static void SubscribeToSystemInputs()
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                OnSwipeRight = OnGoBack;
                return;
            }
        }




        
    }
}
