using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(Image))]
    public class GalleryImage : GalleryElement<WebObject<Sprite>>
    {

        [SerializeField] private Sprite _errorImage;

        private string _url;
        private Image _image;

        public override void Initialize(WebObject<Sprite> onlineSprite)
        {
            _image = GetComponent<Image>();

           _url = onlineSprite.url;
            _image.sprite = onlineSprite.webObject;
        }

        public override void PerformOnClickAction()
        {
            
        }
    }
}
