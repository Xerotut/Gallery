using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using UnityEditor.PackageManager.Requests;
using Unity.VisualScripting;

namespace Gallery
{
    public static class SpriteDonwloader
    {
        //private static UnityWebRequest _request;

        //public static void DownloadSprite(string[] urlParts)
        //{
        //    string url = AssembleURL(urlParts);
        //    _request = UnityWebRequestTexture.GetTexture(url);
        //    _request.SendWebRequest().completed += ;
        //}




        //private static Sprite ReturnImage(AsyncOperation operation)
        //{
        //    if (this == null)
        //    {
        //        return null;
        //    }

        //    var request = ((UnityWebRequestAsyncOperation)operation).webRequest;
        //    if (request.result != UnityWebRequest.Result.Success)
        //    {
        //        Debug.Log(request.error);
        //        return null;
        //    }
            
        //    Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        //    Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        //    return newSprite;
            
        //}



       
    }
}
