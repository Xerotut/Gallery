using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    public class ImageElementAnimations : MonoBehaviour
    {
        private void Start()
        {
            InvokeRepeating(nameof(JustDebug), 0, 0.2f);
        }

        private void JustDebug()
        {
            Debug.Log("Downloading");
        }
    }
}
