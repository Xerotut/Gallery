using UnityEngine;

namespace Gallery
{
    public class OrientationManager : MonoBehaviour, ISceneInitializable
    {
        [SerializeField] private ScreenOrientation _sceneScreenOrientation;
        public void Initialize()
        {
            Screen.orientation = _sceneScreenOrientation;
        }
    }
}
