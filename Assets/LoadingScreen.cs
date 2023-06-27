using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Gallery
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _percentLoaded;
        [SerializeField] private Image _loadingBar;

        private void Start()
        {
            float downloadingTime = Random.Range(2f, 3f); 
            StartCoroutine(LoadSceneAsync(downloadingTime));
        }


        private IEnumerator LoadSceneAsync(float downloadingTime)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneLoadManager.SceneToLoad);
            operation.allowSceneActivation = false;

            float timer = 0;
            while (timer<downloadingTime)
            {
                _loadingBar.fillAmount = timer/downloadingTime;
                _percentLoaded.text = ((int)(timer / downloadingTime * 100)).ToString() + " %";
                timer += Time.deltaTime;
                yield return null;
            }
            operation.allowSceneActivation = true;
            
            while (!operation.isDone) yield return null;
        }

    }
}
