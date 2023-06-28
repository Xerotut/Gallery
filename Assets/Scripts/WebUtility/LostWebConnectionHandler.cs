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

            _tryingToReconnect = false;
        }

        private static bool _tryingToReconnect;

        private static CancellationTokenSource tokenSource; 
        private static CancellationToken _connectionCheckCancelationToken;


        public static event Action OnConnectionLost;
        public static event Action OnConnectionRestored;

        //Used for other scripts to communicate that connection to the internet has been lost.
        public static void ConnectionLost()
        {
            if (!_tryingToReconnect)
            {
                OnConnectionLost?.Invoke();
                _tryingToReconnect = true;

                _connectionCheckCancelationToken = CreateCancelationToken();

                CheckForConnection(_connectionCheckCancelationToken);
            }
        }

        // required to refresh token after successfull webrequest - it is the most straightforward to get rid of old token register callback
        private static CancellationToken CreateCancelationToken()
        {
            tokenSource = new CancellationTokenSource();
            return tokenSource.Token;
        }

        //Since this is a static class, making it async is the only way to make it repeat with set intervals of time.
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
