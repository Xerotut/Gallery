using UnityEngine;

namespace Gallery
{
    public class SceneMaster : MonoBehaviour
    {
   


        private void Awake()
        {
            ISceneInitializable[] initializables = GetComponents<ISceneInitializable>();
            foreach(ISceneInitializable initializable in initializables)
            {
                initializable.Initialize();
            }
        }
    }
}
