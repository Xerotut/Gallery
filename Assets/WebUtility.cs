using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Gallery
{
    public static class WebUtility
    {

        static WebUtility()
        {
            Application.quitting += AbortInProgressRequests;
        }

        private static readonly Dictionary<UnityWebRequest, UnityWebRequestAsyncOperation> _requests = new Dictionary<UnityWebRequest, UnityWebRequestAsyncOperation>();
        private static readonly Dictionary<UnityWebRequestAsyncOperation, Action<AsyncOperation>> _asyncOperations = 
            new Dictionary<UnityWebRequestAsyncOperation, Action<AsyncOperation>>();

        public static void DownloadTexture2D(string url, Action<Texture2D> callback)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

            try
            {
                UnityWebRequestAsyncOperation asyncOperation = request.SendWebRequest();

                Action<AsyncOperation> onRequestCompleteHandler = operation =>
                {
                    HandleWebRequestResult(operation, callback);
                    HandleFinishedRequest(request);
                };

                asyncOperation.completed += onRequestCompleteHandler;
                _requests.Add(request, asyncOperation);
                _asyncOperations.Add(asyncOperation, onRequestCompleteHandler);
            }
            catch
            {
                Debug.LogError("WebRequest gone wrong!!");
                request.Dispose();
            }
        
        }
     
        private static void HandleWebRequestResult(AsyncOperation operation, Action<Texture2D> callback)
        {
            UnityWebRequest request = ((UnityWebRequestAsyncOperation)operation).webRequest;

            if (request == null) return;

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
                callback?.Invoke(null);
                return;
            }

            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            callback?.Invoke(texture);
            
        }


        public static string AssembleURL(string[] urlparts)
        {
            string url = "";
            foreach (string part in urlparts)
            {
                url += part;
            }
            return url;
        }


        private static void AbortInProgressRequests()
        {
            foreach(var request in _requests)
            {
                request.Value.completed -= _asyncOperations[request.Value];
                request.Key.Abort();
                request.Key.Dispose();
            }
            _requests.Clear();
            _asyncOperations.Clear();
        }

        private static void HandleFinishedRequest(UnityWebRequest request)
        {
            _asyncOperations.Remove(_requests[request]);
            _requests.Remove(request);
        }

      

    }
}
