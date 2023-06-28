using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    [CreateAssetMenu(fileName = "ActiveElementData", menuName = "Gallery/Active Element Data")]
    public class ActiveElementData : ScriptableObject
    {
        public Sprite ElementSprite;

        [ field: SerializeField] public Sprite ErrorImage {get; private set;}

        //Used for transfering sprite between scenes.
    }
}
