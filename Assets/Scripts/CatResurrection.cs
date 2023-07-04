using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatResurrection : MonoBehaviour
{
    [SerializeField] GameObject _cat;
    [SerializeField] GridPartition _grid;
    int _cellsRemain;

    private void Start()
    {
        _cellsRemain = 5;
        _grid.GetCell(1, 5).CellOccupied += OnFillCell;
        _grid.GetCell(1, 9).CellOccupied += OnFillCell;
        _grid.GetCell(5, 4).CellOccupied += OnFillCell;
        _grid.GetCell(5, 10).CellOccupied += OnFillCell;
        _grid.GetCell(6, 7).CellOccupied += OnFillCell;
        _grid.GetCell(1, 5).CellFreed += OnCellFree;
        _grid.GetCell(1, 9).CellFreed += OnCellFree;
        _grid.GetCell(5, 4).CellFreed += OnCellFree;
        _grid.GetCell(5, 10).CellFreed += OnCellFree;
        _grid.GetCell(6, 7).CellFreed += OnCellFree;
    }

    void OnCellFree()
    {
        _cellsRemain++;
    }

    void OnFillCell()
    {
        switch (_cellsRemain)
        {
            case 5:
                Noise.StartNoise(0, 1, 0.2f, false);
                break;
            case 4:
                Noise.StartNoise(0, 1, 0.5f, false);
                break;
            case 3:
                Noise.StartNoise(0, 1, 1f, false);
                break;
            case 2:
                Noise.StartNoise(0, 1, 1.2f, false);
                break;
            case 1:
                SpawnTheScariestThingInTheWorld();
                break;
        }


        _cellsRemain--;
    }

    void SpawnTheScariestThingInTheWorld()
    {
        _grid.GetCell(1, 5).CellOccupied -= OnFillCell;
        _grid.GetCell(1, 9).CellOccupied -= OnFillCell;
        _grid.GetCell(5, 4).CellOccupied -= OnFillCell;
        _grid.GetCell(5, 10).CellOccupied -= OnFillCell;
        _grid.GetCell(6, 7).CellOccupied -= OnFillCell;
        _grid.GetCell(1, 5).CellFreed -= OnCellFree;
        _grid.GetCell(1, 9).CellFreed -= OnCellFree;
        _grid.GetCell(5, 4).CellFreed -= OnCellFree;
        _grid.GetCell(5, 10).CellFreed -= OnCellFree;
        _grid.GetCell(6, 7).CellFreed -= OnCellFree;
        _cat.SetActive(true);
        Noise.StartNoise(0.4f, 5, 0.7f, false, 0.001f);
        Destroy(this);
    }
}
