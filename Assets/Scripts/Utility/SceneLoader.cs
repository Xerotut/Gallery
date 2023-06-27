using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gallery
{
    public class SceneLoader : MonoBehaviour
    {

        [SerializeField] string _sceneName;

        public void LoadScene()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
