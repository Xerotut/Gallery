using UnityEngine;

namespace Gallery
{
    public class SceneLoader : MonoBehaviour
    {

        [SerializeField] private string _sceneName;
        [SerializeField] private bool _useLoadingScreen;

        public void LoadScene()
        {
            SceneLoadManager.LoadScene(_sceneName, _useLoadingScreen);
        }
    }
}
