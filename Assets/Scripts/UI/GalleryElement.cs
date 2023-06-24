using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    public abstract class GalleryElement<T> : MonoBehaviour
    {

        public abstract void Initialize(T elementDisplayObject);


        public abstract void PerformOnClickAction();

    }
}
