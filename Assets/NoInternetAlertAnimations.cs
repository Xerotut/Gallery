using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    [RequireComponent(typeof(Animator))]
    public class NoInternetAlertAnimations : MonoBehaviour
    {
        private Animator _alertAnimator;


        private void Awake()
        {
            _alertAnimator = GetComponent<Animator>();
        }

        private void StartAlert()
        {
            _alertAnimator.SetTrigger("ConnectionLost");
        }

        private void StopAlert()
        {
            _alertAnimator.SetTrigger("ConnectionRestored");
        }

        private void OnEnable()
        {
            WebUtility.OnConnectionLost += StartAlert;
            WebUtility.OnConnectionRestored += StopAlert;
        }

        private void OnDisable()
        {
            WebUtility.OnConnectionLost -= StartAlert;
            WebUtility.OnConnectionRestored -= StopAlert;
        }

    }
}
