using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellCreator : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected List<Cell> createdCells = new List<Cell>();


    private void Start()
    {
        Cell.CaptureCell.AddListener(RemoveCreatedCell);
    }

    public abstract Cell CreateCell();
    public abstract Cell CreateCellAt(Vector3 spawnPos,Cell parent = null);
    public List<Cell> CreatedCells() => createdCells;
    private void RemoveCreatedCell(Cell cell) => createdCells.Remove(cell);
}
