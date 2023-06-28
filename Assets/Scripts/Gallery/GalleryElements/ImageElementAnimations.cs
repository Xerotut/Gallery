using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(Image))]
    [RequireComponent (typeof(Animator))]
    public class ImageElementAnimations : MonoBehaviour
    {

        private Animator _imageElementAnimator;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _imageElementAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(JustDebug), 0, 0.2f);
        }

        private void JustDebug()
        {
            if (_image.sprite != null)
            {
                _imageElementAnimator.SetTrigger("ImageDownloaded");
                CancelInvoke();
            }
        }
    }
}
