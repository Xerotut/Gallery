
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class ImageGrid : MonoBehaviour
    {
        [SerializeField] private GameObject _gridElement;
        [SerializeField] private Canvas _canvas;



        private GridLayoutGroup _gridLayoutGroup;

        private void Awake()
        {
            _gridLayoutGroup = GetComponent<GridLayoutGroup>();
            if (_canvas == null) _canvas = GetComponentInParent<Canvas>();
        }

        private void Start()
        {

            int screenWidth = (int)(Screen.width / _canvas.scaleFactor);
            int screenHeight = (int)(Screen.height/_canvas.scaleFactor);

            int cellWidth = (int)_gridLayoutGroup.cellSize.x;
            int cellHeight = (int)_gridLayoutGroup.cellSize.y;

            int columns = 0;
            int rows = 0;   

            switch (_gridLayoutGroup.constraint)
            {
                
                case GridLayoutGroup.Constraint.FixedRowCount:
                    rows = _gridLayoutGroup.constraintCount;
                    columns = screenWidth / cellWidth;
                    break;
                case GridLayoutGroup.Constraint.FixedColumnCount:
                    rows = screenHeight / cellHeight;
                    columns = _gridLayoutGroup.constraintCount;
                    break;
                case GridLayoutGroup.Constraint.Flexible:
                    rows = screenHeight / cellHeight;
                    columns = screenWidth / cellWidth;
                    break;
            }
         
            for (int i = 0; i < rows * columns*2; i++) 
            {
                Instantiate(_gridElement, _gridLayoutGroup.transform);
            }
        }

        public void Test(Vector2 vector)
        {
            if (vector.y <= 0)
            {
                Instantiate(_gridElement, _gridLayoutGroup.transform);
                Instantiate(_gridElement, _gridLayoutGroup.transform);
            }
        }
    }
}
