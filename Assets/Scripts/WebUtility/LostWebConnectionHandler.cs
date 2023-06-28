using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Gallery
{
    public static class LostWebConnectionHandler
    {

        static LostWebConnectionHandler()
        {
            Application.quitting += () => tokenSource?.Cancel(); ;
            SceneManager.activeSceneChanged += HandleSceneChange;

            TryingToReconnect = false;
        }

        public static bool TryingToReconnect { get; private set; }

        private static CancellationTokenSource tokenSource; 
        private static CancellationToken _connectionCheckCancelationToken;


        public static event Action OnConnectionLost;
        public static event Action OnConnectionRestored;

        public static void ConnectionLost()
        {
            OnConnectionLost?.Invoke();
            TryingToReconnect = true;

            _connectionCheckCancelationToken = CreateCancelationToken();

            CheckForConnection(_connectionCheckCancelationToken);
        }


        private static CancellationToken CreateCancelationToken()
        {
            tokenSource = new CancellationTokenSource();
            return tokenSource.Token;
        }

        private static async void CheckForConnection(CancellationToken cancelationToken)
        {
            try
            {
                await Task.Delay(2000, cancelationToken);
                UnityWebRequest request = new UnityWebRequest("http://data.ikppbb.com/test-task-unity-data/pics/1.jpg", "HEAD");
                AsyncOperation operation = request.SendWebRequest();
                operation.completed += ConnectionCheckResult;
                cancelationToken.Register(() =>
                {
                    operation.completed -= ConnectionCheckResult;
                    request.Abort();
                    request.Dispose();
                });
            } catch (OperationCanceledException)
            {
                Debug.Log("Exited before web connection check.");
            }
        }



        private static void ConnectionCheckResult(AsyncOperation operation)
        {
           
            UnityWebRequest request = ((UnityWebRequestAsyncOperation)operation).webRequest;
            if (request.responseCode == 0)
            {
                _connectionCheckCancelationToken = CreateCancelationToken();
                CheckForConnection(_connectionCheckCancelationToken);
            }
            else
            {
                OnConnectionRestored?.Invoke();
            }
            request.Dispose();
            
        }



        private static void HandleSceneChange(Scene current, Scene next)
        {
            tokenSource?.Cancel();
        }
      

    }
}
