using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Gallery
{
    public static class WebUtility
    {

        public static event Action OnDownloadStart;
        public static event Action OnDownloadEnd;
        

        static WebUtility()
        {
            Application.quitting += AbortInProgressRequests;
            SceneManager.activeSceneChanged += HandleSceneChange;

            LostWebConnectionHandler.OnConnectionRestored += () =>
            {
                foreach (UnityWebRequest request in _pendingRequests.Keys)
                {
                    SendRequest(request, _pendingRequests[request]);
                }
            };
        }

        private readonly static HashSet<UnityWebRequest> _requestsInProgress = new HashSet<UnityWebRequest>();

        private readonly static Dictionary<UnityWebRequest, Action<UnityWebRequest>> _pendingRequests = new Dictionary<UnityWebRequest, Action<UnityWebRequest>>();

        public static void CheckIfPageExists(string url, Action<UnityWebRequest> callback)
        {
            UnityWebRequest request = new UnityWebRequest(url, "HEAD");
            SendRequest(request, callback);
        }

        public static void DownloadTexture2D(string url, Action<UnityWebRequest> callback)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            SendRequest(request, callback);
        }
     
        private static void SendRequest(UnityWebRequest request, Action<UnityWebRequest> callback)
        {
            OnDownloadStart?.Invoke();
            try
            {
                void OnRequestCompleteHandler(AsyncOperation operation)
                {
                    HandleWebRequestResult(operation, callback);
                    HandleFinishedRequest(request);
                }

                request.SendWebRequest().completed += OnRequestCompleteHandler;
                _requestsInProgress.Add(request);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                request.Abort();
                if (_requestsInProgress.Contains(request)) _requestsInProgress.Remove(request);
                request.Dispose();
            }
        }

        private static void HandleWebRequestResult(AsyncOperation operation, Action<UnityWebRequest> callback)
        {
            UnityWebRequest request = ((UnityWebRequestAsyncOperation)operation).webRequest;

            if (_requestsInProgress.Contains(request))
            {
                if (request.result != UnityWebRequest.Result.Success)
                {
                    if (request.responseCode == 0)
                    {
                        
                        UnityWebRequest storedRequest = new UnityWebRequest(request.url, request.method, request.downloadHandler, request.uploadHandler);
                        _pendingRequests.Add(storedRequest, callback);
                        LostWebConnectionHandler.ConnectionLost();
                        return;
                    }
                }
                
                callback?.Invoke(request);
               
            }
           
        }

       

        private static void AbortInProgressRequests()
        {
            foreach(var request in _requestsInProgress)
            {
                request.Abort();
                request.Dispose();
            }
            _requestsInProgress.Clear();
            _pendingRequests.Clear();
        }

        private static void HandleFinishedRequest(UnityWebRequest request)
        {
            if (_requestsInProgress.Contains(request)) _requestsInProgress.Remove(request);
            if (_requestsInProgress.Count == 0)
            {
                OnDownloadEnd?.Invoke();
            }
        }

        private static void HandleSceneChange(Scene current, Scene next)
        {
            AbortInProgressRequests();
        }

    }
}
