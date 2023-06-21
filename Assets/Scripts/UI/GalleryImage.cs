using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(Image))]
    public class GalleryImage : MonoBehaviour
    {
        private static int numberOfImages =0;

        [SerializeField] private string _url;
        [SerializeField] private Sprite _errorImage;

        private Image _image;

        private void Awake()
        {
            numberOfImages++;
            string url = WebUtility.AssembleURL(new string[] {_url, numberOfImages.ToString(),".jpg" });
            _image = GetComponent<Image>();
            WebUtility.DownloadTexture2D(url, sprite => AssignSprite(sprite));
            //StartCoroutine(GetTexture(url));
            
        }


        private void AssignSprite(Texture2D texture)
        {
            Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            _image.sprite = newSprite;
        }

        //private IEnumerator GetTexture(string url)
        //{
        //    UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        //    yield return request.SendWebRequest();
        //    if (request.result != UnityWebRequest.Result.Success)
        //    {
        //        Debug.Log(request.error);
        //        _image.sprite = _errorImage;
        //        yield break;
        //    }
            
        //    Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        //    Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f)); 
        //    _image.sprite = newSprite;
            
        //}

      

    }
}
