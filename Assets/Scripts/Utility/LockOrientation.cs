using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    public class LockOrientation : MonoBehaviour
    {
        void Start()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
