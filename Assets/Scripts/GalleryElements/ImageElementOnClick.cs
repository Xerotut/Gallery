using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(SceneLoader))]
    public class ImageElementOnClick : MonoBehaviour
    {


        [SerializeField] ActiveElementData _dataContainer;

        private SceneLoader _sceneLoader;

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            _sceneLoader = GetComponent<SceneLoader>();
            _image.preserveAspect = true;
        }

       
        public void PerformOnClickAction()
        {
            if (_image.sprite != null)
            {
                _dataContainer.ElementSprite = _image.sprite;
                _sceneLoader.LoadScene();
            }
        }
    }
}
