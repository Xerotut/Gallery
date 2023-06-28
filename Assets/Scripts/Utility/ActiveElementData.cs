using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    [CreateAssetMenu(fileName = "ActiveElementData", menuName = "Gallery/Active Element Data")]
    public class ActiveElementData : ScriptableObject
    {
        //Used for transfering sprite between scenes.
       
        public Sprite ElementSprite;

        [ field: SerializeField] public Sprite ErrorImage {get; private set;}

    }
}
