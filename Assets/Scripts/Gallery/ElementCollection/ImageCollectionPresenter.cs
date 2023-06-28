using System;
using System.Collections;
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





        public void RequestImages(int imagesPresent,int numberOfImagesRequested, IImageRequestor requestor)
        {
            for (int i = imagesPresent+1; i<= imagesPresent + numberOfImagesRequested; i++)
            {
                string url = WebUtility.AssembleURL(new string[] { _urlDomain, i.ToString(), ".jpg"});
                WebUtility.CheckIfPageExists(url, request => SatisfyRequest(request, requestor, url));
                
            }
        }

        private void SatisfyRequest(UnityWebRequest request, IImageRequestor requestor, string url)
        {
            if (request.responseCode !=200) 
            {
                requestor.OnRequestAnswered(false);
                return;
            }
            requestor.OnRequestAnswered(true);
            WebUtility.DownloadTexture2D(url, request => OnTextureDownload(request, requestor));

        }

        private void OnTextureDownload(UnityWebRequest request, IImageRequestor requestor)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            if (texture== null)
            {
                requestor.OnSpriteReady(_errorImage);
                return;
            }
            Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            requestor.OnSpriteReady(newSprite);
        }
    }
}
