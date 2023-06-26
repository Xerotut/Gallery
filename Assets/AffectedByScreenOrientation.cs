using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gallery
{
    public class AffectedByScreenOrientation : MonoBehaviour
    {
        public ScreenOrientation ScreenOrientation;
        private ScreenOrientation lastOrientation;

        public RectTransform rect;

        private void Start()
        {
            lastOrientation = ScreenOrientation;
        }

        private void Update()
        {
            if (ScreenOrientation == ScreenOrientation.LandscapeLeft)
            {
                rect.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (ScreenOrientation == ScreenOrientation.LandscapeRight)
            {
                rect.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                rect.rotation = Quaternion.identity;
            }
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
        }
       
    }
}
