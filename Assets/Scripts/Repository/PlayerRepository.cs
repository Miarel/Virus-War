using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepository : UnitRepository
{
    [SerializeField] private Virus virusPrefab;

    private void Start()
    {
        virus = virusPrefab;
        Cell.CreateCell.AddListener(AddCell);
        Cell.CaptureCell.AddListener(RemoveCell);
        Cell.CaptureCell.AddListener( UnSelectDestroyCell);
    }

    public void SwitchSellectCell(Cell cell)
    {
        if (cell is PlayerCell && cells.Contains(cell))
        {
            if (selectedCells.Contains(cell))
            {
                UnSelectCell.Invoke(cell);
                selectedCells.Remove(cell);
            }
            else
            {
                SelectCell.Invoke(cell);
                selectedCells.Add(cell);
            }
        }
    }

    public void UnSelectCells()
    {
        foreach (var cell in selectedCells)
        {
            UnSelectCell.Invoke(cell);
        }

        selectedCells.Clear();
    }


    public List<Cell> GetSelectedCells() => new List<Cell>(selectedCells);

    public override List<Cell> GetCells() => new List<Cell>(cells);

    public override Virus GetVirus() => virus;

    public override void AddCell(Cell cell) 
    {
        if(!cells.Contains(cell) && cell is PlayerCell)
            cells.Add(cell);
    }

    private void UnSelectDestroyCell(Cell cell)
    {
        selectedCells.Remove(cell);
    }

    public override void RemoveCell(Cell cell) => cells.Remove(cell);
}
