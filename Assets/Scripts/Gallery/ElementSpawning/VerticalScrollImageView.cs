using Gallery;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    public class VerticalScrollImageView: MonoBehaviour, IView
    {
        [SerializeField] private GridParametersCalculator _availableSpaceCalculator;

        [SerializeField] private GameObject _imageGameObject;
        [SerializeField] private ImageCollectionPresenter _imageCollection;
        [SerializeField] private Transform _imageObjectsContainer;


        private readonly Queue<Image> _imagesInProgress = new Queue<Image>();

        private int _imagesRequested =0;

        private bool _canRequest = true;

        private void Start()
        {
            RequestImage(_availableSpaceCalculator.ScreenOverallAvailableSpace());
            _canRequest = false;
        }


       
        
        private void RequestImage(int numberOfImages)
        {
            _imageCollection.RequestImages(_imagesRequested, numberOfImages, this);
            _imagesRequested += numberOfImages;
        }

        public void OnRequestAnswered(bool isImageExists)
        {
            if (!isImageExists)
            {
                return;
            }

            SpawnImageObject();
        }

        private void SpawnImageObject()
        {
            GameObject newImageObject = Instantiate(_imageGameObject, _imageObjectsContainer);
            Image image = newImageObject.GetComponent<Image>();
            _imagesInProgress.Enqueue(image);
            _canRequest = true;
        }

        public void OnSpriteReady(Sprite sprite)
        {
            Image imageToAssignTo = _imagesInProgress.Dequeue();
            imageToAssignTo.sprite = sprite;
        }

        public void CheckIfMoreElementsRequired(Vector2 scrollViewPosition)
        {
            if (scrollViewPosition.y <= 0 && _canRequest)
            {
                RequestImage(_availableSpaceCalculator.ScreenHorizontalAvailableSpace());
                _canRequest = false;
            }
        }


    }
}
