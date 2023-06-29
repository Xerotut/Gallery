using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Gallery
{
    [CreateAssetMenu(fileName = "Image Collection", menuName = "Gallery/Image Collection")]
    public class ImageCollectionPresenter : ScriptableObject
    {

        [SerializeField] private Sprite _errorImage;

        [SerializeField] private string _urlDomain;

        private int _imagesRequested;


        //Required to connect view and Presenter
        public void RegisterView(IView view)
        {
            _imagesRequested = 0;
            view.OnViewRequest += RequestImages;
        }


        /// <summary>
        /// Function that triggers by view OnViewRequest. Made it so it firstly checks whether or not the page with the image exists
        /// and starts downloading only if it does - that allows to spawn image objects as soon as possible and fill them with images later (and also stop spawnning them
        /// if there is no more images).
        /// </summary>
        /// <param name="numberOfImagesRequested"> Number of images view wants to recieve</param>
        /// <param name="view"> The requesting view</param>
        private void RequestImages(int numberOfImagesRequested, IView view)
        {
            for (int i = _imagesRequested + 1; i<= _imagesRequested + numberOfImagesRequested; i++)
            {
                string url = WebUtilityUrl.AssembleURL(new string[] { _urlDomain, i.ToString(), ".jpg"});
                
                WebUtility.CheckIfPageExists(url, request => SatisfyRequest(request, view, url));
               
            }
            _imagesRequested += numberOfImagesRequested;

        }

        private void SatisfyRequest(UnityWebRequest request, IView view, string url)
        {
            if (request.responseCode !=200) 
            {
                view.OnRequestAnswered(false);
                return;
            }
            view.OnRequestAnswered(true);
            WebUtility.DownloadTexture2D(url, request => OnTextureDownload(request, view, url));

        }

        private void OnTextureDownload(UnityWebRequest request, IView view, string url)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            if (texture== null)
            {
                view.OnSpriteReady(_errorImage);
                return;
            }
            Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            view.OnSpriteReady(newSprite);
        }

      

    }
}
