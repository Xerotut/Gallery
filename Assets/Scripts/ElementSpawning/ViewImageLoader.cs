using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    public class ViewImageLoader : MonoBehaviour
    {
        [SerializeField] private ActiveElementData _passedData;

        private Sprite _sprite;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();


            if (_passedData.ElementSprite == null)
            {
                _sprite = _passedData.ErrorImage;
                Debug.LogError("No image was passed!");
            }
            else
            {
                Debug.Log(_passedData.ElementSprite.name);
                _sprite = _passedData.ElementSprite;
            }
            _image.sprite = _sprite;


            //donwload image if no sprite
        }
    }
}
