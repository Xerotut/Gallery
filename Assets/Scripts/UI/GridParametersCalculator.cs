using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class GridParametersCalculator : MonoBehaviour, IScreenAvailableSpace
    {
        [SerializeField] private Canvas _canvas;

        private int _columns;
        private int _rows;

        private int _totalGridFreeSpace;


        private GridLayoutGroup _gridLayoutGroup;

        private int _screenWidth;
        private int _screenHeight;

        private int _cellWidth;
        private int _cellHeight;

       

        private void Awake()
        {
            _gridLayoutGroup = GetComponent<GridLayoutGroup>();
            if (_canvas == null) _canvas = GetComponentInParent<Canvas>();
            CalculateScreenParams();
            CalculateGridParameters();
        }

        private void CalculateScreenParams()
        {
            _screenWidth = (int)(Screen.width / _canvas.scaleFactor);
            _screenHeight = (int)(Screen.height / _canvas.scaleFactor);

            _cellWidth = (int)_gridLayoutGroup.cellSize.x;
            _cellHeight = (int)_gridLayoutGroup.cellSize.y;
        }

        private void CalculateGridParameters()
        {

            switch (_gridLayoutGroup.constraint)
            {

                case GridLayoutGroup.Constraint.FixedRowCount:
                    _rows = _gridLayoutGroup.constraintCount;
                    _columns = _screenWidth / _cellWidth;
                    break;
                case GridLayoutGroup.Constraint.FixedColumnCount:
                    _rows = _screenHeight / _cellHeight;
                    _columns = _gridLayoutGroup.constraintCount;
                    break;
                case GridLayoutGroup.Constraint.Flexible:
                    _columns = _screenWidth / _cellWidth;
                    _rows = _screenHeight / _cellHeight;
                    break;
            }

            _totalGridFreeSpace = _rows * _columns;
            
        }

        public int ScreenOverallAvailableSpace()
        {
            return _totalGridFreeSpace;
        }

        public int ScreenHorizontalAvailableSpace()
        {
            return _columns;
        }

        public int ScreenVerticalAvailableSpace()
        {
            return _rows;
        }
    }
}
