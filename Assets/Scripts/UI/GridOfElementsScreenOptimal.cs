using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class GridOfElementsScreenOptimal : MonoBehaviour
    {
        [SerializeField] private GameObject _gridElement;
        [SerializeField] private Canvas _canvas;

        [SerializeField] private List<Sprite> _images;

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
         
            for (int i = 0; i < rows * columns; i++) 
            {
                SpawnElement();
            }
        }


        private void SpawnElement()
        {
            Instantiate(_gridElement, _gridLayoutGroup.transform);
        }


        public void OnGridInteraction(Vector2 position)
        {
            if (position.y <= 0)
            {
                SpawnElement();
            }
        }
        
    }
}
