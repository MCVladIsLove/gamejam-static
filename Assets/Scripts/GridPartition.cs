using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPartition : MonoBehaviour
{
    [SerializeField] int _columns, _rows;
    [SerializeField] GameObject _cell;

    GridCell[] _cells;
    RectTransform _gridRect;
    
    public int Capacity { get { return _columns * _rows; } }
    private void Awake()
    {
        _gridRect = GetComponent<RectTransform>();
        _cells = new GridCell[_columns * _rows];

        float cellWidth = _gridRect.rect.width / _columns;
        float cellHeight = _gridRect.rect.height / _rows;
        Vector2 scale = new Vector2(cellWidth, cellHeight);
        GameObject cell;
        for (int y = 0; y < _rows; y++)
            for (int x = 0; x < _columns; x++)
            {
                Vector3 cellCenter = new Vector3(x * cellWidth + cellWidth / 2, _gridRect.rect.height - y * cellHeight - cellHeight / 2);
                cell = Instantiate(_cell);
                cell.name = $"cell {y} {x}";
                _cells[x + y * _columns] = cell.GetComponent<GridCell>();
                _cells[x + _columns * y].Init(transform, scale, cellCenter);
            }
    }

    public void FillCell(int column, int row, GameObject filler)
    {
        if (_cells[column + row * _columns].IsOccupied == false)
            _cells[column + row * _columns].Fill(filler); 
    }
    public void FillCell(int i, GameObject filler)
    {
        if (_cells[i].IsOccupied == false)
            _cells[i].Fill(filler);
    }

    public GridCell GetCell(int i)
    {
        return _cells[i];
    }
    public GridCell GetCell(int column, int row)
    {
        return _cells[column * _columns + row ];
    }
}
