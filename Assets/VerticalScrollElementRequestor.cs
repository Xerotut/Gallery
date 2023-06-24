using Gallery;
using System;
using UnityEngine;

namespace Gallery
{
    public class VerticalScrollElementRequestor : ElementRequestor
    {
        [SerializeField] private GridParametersCalculator _availableSpaceCalculator;


        void Start()
        {
            RequestElements(_availableSpaceCalculator.ScreenOverallAvailableSpace());
        }


        public void CheckIfMoreElementsRequired(Vector2 scrollViewPosition)
        {
            if (scrollViewPosition.y <= 0)
            {
                RequestElements(_availableSpaceCalculator.ScreenHorizontalAvailableSpace());
            }
        }



    }
}
