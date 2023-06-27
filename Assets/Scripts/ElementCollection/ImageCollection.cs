using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    [CreateAssetMenu(fileName = "Image Collection", menuName = "Gallery/Image Collection")]
    public class ImageCollection : ScriptableObject
    {

        [SerializeField] private Sprite _errorImage;

        [SerializeField] private string _urlDomain;





        public void RequestImages(int imagesPresent,int numberOfImagesRequested, IImageRequestor requestor)
        {
            for (int i = imagesPresent+1; i<= imagesPresent + numberOfImagesRequested; i++)
            {
                string url = WebUtility.AssembleURL(new string[] { _urlDomain, i.ToString(), ".jpg"});
                Debug.Log(url);
                WebUtility.CheckIfPageExists(url, elementExists => SatisfyRequest(elementExists, requestor, url));
                
            }
        }

        private void SatisfyRequest(bool isElementExist, IImageRequestor requestor, string url)
        {
            requestor.OnRequestAnswered(isElementExist);
            Debug.Log(isElementExist);
            if (!isElementExist) return;

            WebUtility.DownloadTexture2D(url, texture => OnTextureDownload(texture, requestor));
        }

        private void OnTextureDownload(Texture2D texture, IImageRequestor requestor)
        {
            if (texture== null)
            {
                requestor.OnSpriteReady(_errorImage);
            }
            Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            requestor.OnSpriteReady(newSprite);
        }
    }
}
