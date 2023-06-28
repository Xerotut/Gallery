using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gallery
{
    public class SystemInputsLocal : MonoBehaviour, ISceneInitializable
    {

        public void Initialize()
        {
        }

        [SerializeField] private GoToPreviousSceneVariants _backButtonOption;
        [SerializeField] private SceneLoader _sceneToLoadData;

        private void ReturnToPreviousScene()
        {
            switch (_backButtonOption)
            {
                case GoToPreviousSceneVariants.IndexBased:
                    int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
                    if (currentSceneBuildIndex > 0)
                    {
                        SceneManager.LoadScene(currentSceneBuildIndex - 1);
                        return;
                    }
                    Application.Quit();
                    break;
                case GoToPreviousSceneVariants.CustomSceneLoader:
                    if (_sceneToLoadData == null)
                    {
                        Debug.LogError("No Scene Loader attached");
                        return;
                    }
                    _sceneToLoadData.LoadScene();
                    break;
                case GoToPreviousSceneVariants.Exit:
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
