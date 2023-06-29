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

        private bool _canRequest = true;

        public event Action<int, IView> OnViewRequest;

        private void Start()
        {
            _canRequest = false;
            _imageCollection.RegisterView(this);
            RequestImage(_availableSpaceCalculator.ScreenOverallAvailableSpace());
        }



        private void RequestImage(int numberOfImages)
        {
            OnViewRequest?.Invoke(numberOfImages, this);
        }

        //Since it requests image from the internet, the user experience is more smooth if an image object is spawn as soon as 
        //it is confirmed there is an image on the server - the actual image is attached to it later, after the download is finished.
        public void OnRequestAnswered(bool isImageExists)
        {
            if (!isImageExists)
            {
                return;
            }

            SpawnImageObject();
        }

        //imageObject has a blank image, which will be filled after 
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

        // Used by scroll view - this recieves vector2 every time the user drags it. Vector2 is the current position of the scroll view.
        public void CheckIfMoreElementsRequired(Vector2 scrollViewPosition)
        {
            if (scrollViewPosition.y <= 0 && _canRequest)
            {
                _canRequest = false;
                RequestImage(_availableSpaceCalculator.ScreenHorizontalAvailableSpace());
            }
        }


    }
}
