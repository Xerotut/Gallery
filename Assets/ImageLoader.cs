using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    public class ImageLoader : MonoBehaviour
    {
        [SerializeField] private ActiveElementData _passedData;

        private string _url;

        private Sprite _sprite;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();

            _url = _passedData.Url;

            if (_passedData.ElementSprite != null)
            {
                _sprite = _passedData.ElementSprite;
                _image.sprite = _sprite;
                return;
            }

            //donwload image if no sprite
        }
    }
}
