using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gallery
{
    public static class SceneLoadManager
    {
        public static string SceneToLoad { get; private set; }

        public static void LoadScene(string _sceneName, bool useLoadingScreen)
        {
            if (_sceneName != null) 
            {
                if (useLoadingScreen)
                {
                    SceneToLoad = _sceneName;
                    SceneManager.LoadScene("LoadingScene");
                    return;
                }

                SceneManager.LoadScene(_sceneName);

            }
        }

    }
}
