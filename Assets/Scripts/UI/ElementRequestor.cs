using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    public class ElementRequestor : MonoBehaviour, IElementRequestor
    {
        public event Action<int> OnRequestElements;

        protected void RequestElements(int numberOfElements)
        {
            OnRequestElements?.Invoke(numberOfElements);
        }
    }
}
