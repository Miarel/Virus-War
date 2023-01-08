using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRepository : UnitRepository
{
    [SerializeField] private Virus virusPrefab;

    private void Start()
    {
        virus = virusPrefab;
        Cell.CreateCell.AddListener(AddCell);
        Cell.CaptureCell.AddListener(RemoveCell);
    }

    public override void RemoveCell(Cell cell) => cells.Remove(cell);

    public override List<Cell> GetCells() => new List<Cell>(cells);

    public override Virus GetVirus() => virus;

    public override void AddCell(Cell cell) 
    {
        if (!cells.Contains(cell) && cell is EnemyCell)
            cells.Add(cell);
    }
    
}
