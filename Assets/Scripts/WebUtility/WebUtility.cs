using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Gallery
{
    public static class WebUtility
    {

        public static event Action OnDownloadStart;
        public static event Action OnDownloadEnd;
        public static event Action OnConnectionLost;
        public static event Action OnConnectionRestored;

        static WebUtility()
        {
            Application.quitting += AbortInProgressRequests;
            SceneManager.activeSceneChanged += HandleSceneChange;

            OnConnectionLost += CheckForConnection;
        }

        private static HashSet<UnityWebRequest> _requests = new HashSet<UnityWebRequest>();
        //private static HashSet<UnityWebRequest> _requests = new HashSet<UnityWebRequest>();


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

                Action<AsyncOperation> onRequestCompleteHandler = operation =>
                {
                    HandleWebRequestResult(operation, callback);
                    HandleFinishedRequest(request);
                };

                request.SendWebRequest().completed += onRequestCompleteHandler;
                _requests.Add(request);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                request.Abort();
                if (_requests.Contains(request)) _requests.Remove(request);
                request.Dispose();
            }
        }

        private static void HandleWebRequestResult(AsyncOperation operation, Action<UnityWebRequest> callback)
        {
            UnityWebRequest request = ((UnityWebRequestAsyncOperation)operation).webRequest;

            if (_requests.Contains(request))
            {
                if (request.result != UnityWebRequest.Result.Success)
                {
                    if (request.responseCode == 0)
                    {
                        OnConnectionLost?.Invoke();
                        UnityWebRequest storedRequest = new UnityWebRequest(request.url, request.method, request.downloadHandler, request.uploadHandler);

                        Action OnContinueRequest = null;
                        OnContinueRequest = () =>
                        {

                            SendRequest(storedRequest, callback);
                            OnConnectionRestored -= OnContinueRequest;
                        };
                        OnConnectionRestored += OnContinueRequest;

                        return;
                    }
                }


                try
                {
                    callback?.Invoke(request);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
           
        }

        private static async void CheckForConnection()
        {
            await Task.Delay(2000);
            UnityWebRequest request = new UnityWebRequest("http://data.ikppbb.com/test-task-unity-data/pics/1.jpg", "HEAD");
            request.SendWebRequest().completed += ConnectionCheckResult;

        }
        private static void ConnectionCheckResult(AsyncOperation operation)
        {
            UnityWebRequest request = ((UnityWebRequestAsyncOperation)operation).webRequest;
            if (request.responseCode == 0)
            {
                CheckForConnection();
                return;
            }
            OnConnectionRestored?.Invoke();
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
                request.Abort();
                request.Dispose();
            }
            _requests.Clear();
        }

        private static void HandleFinishedRequest(UnityWebRequest request)
        {
            if (_requests.Contains(request)) _requests.Remove(request);
            if (_requests.Count == 0)
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
