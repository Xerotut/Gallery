using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    public abstract class ElementSpawner<T,RequestorType> : MonoBehaviour where RequestorType : IElementRequestor
    {
        [SerializeField] private GalleryElement<T> _element;
        [SerializeField] private Transform _elementsContainer;
        [SerializeField] private RequestorType _requestor;

        protected virtual void Awake()
        {
            if (_elementsContainer == null) _elementsContainer = transform;
            _requestor.OnRequestElements += SatisfyElementRequirement;
        }


        protected abstract void SatisfyElementRequirement(int numberOfElements);

        protected virtual void SpawnElement(T elementData)
        {
            GalleryElement<T> element = Instantiate(_element, _elementsContainer);
            element.Initialize(elementData);
        }

    }
}
