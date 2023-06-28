using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gallery
{
    public class SystemInputs : MonoBehaviour, ISceneInitializable
    {

        public void Initialize()
        {
        }

        [SerializeField] private PreviousSceneOptions _backButtonOption;
        
        private SceneLoader _sceneToLoadData;

        private void ReturnToPreviousScene()
        {
            switch (_backButtonOption)
            {
                case PreviousSceneOptions.IndexBased:
                    int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
                    if (currentSceneBuildIndex > 0)
                    {
                        SceneManager.LoadScene(currentSceneBuildIndex - 1);
                        return;
                    }
                    Application.Quit();
                    break;
                case PreviousSceneOptions.CustomSceneLoader:
                    _sceneToLoadData = GetComponent<SceneLoader>();
                    if (_sceneToLoadData == null)
                    {
                        Debug.LogError("No Scene Loader attached");
                        return;
                    }
                    _sceneToLoadData.LoadScene();
                    break;
                case PreviousSceneOptions.Exit:
                    Application.Quit();
                    break;
            }
        }

        private void OnEnable()
        {
            InputReader.OnGoBack += ReturnToPreviousScene;
        }
        private void OnDisable()
        {
            InputReader.OnGoBack -= ReturnToPreviousScene;
        }


    }
}
