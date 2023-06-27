using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(SceneLoader))]
    public class ImageElementOnClick : MonoBehaviour
    {


        [SerializeField] ActiveElementData _dataContainer;

        private SceneLoader _sceneLoader;

        private void Start()
        {
            _sceneLoader = GetComponent<SceneLoader>();
        }

       
        public void PerformOnClickAction()
        {
            _dataContainer.ElementSprite = GetComponent<Image>().sprite;

            _sceneLoader.LoadScene();
        }
    }
}
