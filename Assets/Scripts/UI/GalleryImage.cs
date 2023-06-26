using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(SceneLoader))]
    public class GalleryImage : GalleryElement<WebObject<Sprite>>
    {

        [SerializeField] private Sprite _errorImage;

        [SerializeField] ActiveElementData _dataContainer;

        private string _url;
        private Image _image;

        private SceneLoader _sceneLoader;

        public override void Initialize(WebObject<Sprite> onlineSprite)
        {
            _image = GetComponent<Image>();

           _url = onlineSprite.url;
            _image.sprite = onlineSprite.webObject;

            _sceneLoader = GetComponent<SceneLoader>();
        }

        public override void PerformOnClickAction()
        {
            _dataContainer.Url = _url;
            _dataContainer.ElementSprite = _image.sprite;

            _sceneLoader.LoadScene();
        }
    }
}
