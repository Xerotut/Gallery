using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Gallery
{
    public static class WebUtility
    {

        static WebUtility()
        {
            Application.quitting += AbortInProgressRequests;
            SceneManager.activeSceneChanged += HandleSceneChange;
        }

        private static readonly Dictionary<UnityWebRequest, UnityWebRequestAsyncOperation> _requests = new Dictionary<UnityWebRequest, UnityWebRequestAsyncOperation>();
        private static readonly Dictionary<UnityWebRequestAsyncOperation, Action<AsyncOperation>> _asyncOperations = 
            new Dictionary<UnityWebRequestAsyncOperation, Action<AsyncOperation>>();

        public static void CheckIfPageExists(string url, Action<bool> callback)
        {
            UnityWebRequest request = new UnityWebRequest(url, "HEAD");
            SendRequest(request, callback);
        }

        public static void DownloadTexture2D(string url, Action<Texture2D> callback)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            SendRequest(request, callback);
        }
     
        private static void SendRequest<T>(UnityWebRequest request, Action<T> callback)
        {
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
            catch (Exception e)
            {
                Debug.LogError(e);
                request.Abort();
                if (_asyncOperations.ContainsKey(_requests[request])) _asyncOperations.Remove(_requests[request]);
                if (_requests.ContainsKey(request)) _requests.Remove(request);
                request.Dispose();
            }
        }

        private static void HandleWebRequestResult<T>(AsyncOperation operation, Action<T> callback)
        {
            UnityWebRequest request = ((UnityWebRequestAsyncOperation)operation).webRequest;

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
                try
                {
                callback?.Invoke(default);
                } catch (Exception e)
                {
                    Debug.LogError(e);
                }
                return;
            }

            if (typeof(T) == typeof(Texture2D))
            {
                Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                try
                {
                    callback?.Invoke((T)(object)texture);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
            else if(typeof(T) == typeof(bool)) 
            {
                try
                {
                    callback?.Invoke((T)(object)true);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }

            }
           
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

        private static void HandleSceneChange(Scene current, Scene next)
        {
            AbortInProgressRequests();
        }

    }
}
