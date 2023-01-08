using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralCellCreator : CellCreator
{

    public override Cell CreateCell()
    {
        var pos = Vector3.zero;

        return CreateCellAt(pos);
    }

    public override Cell CreateCellAt(Vector3 spawnPos,Cell parent = null)
    {
        var neutrallCell = Instantiate(prefab, spawnPos, Quaternion.identity).AddComponent<NeutralCell>();
        neutrallCell.name = $"Neutral X:{spawnPos.x} Y:{spawnPos.y}";
        neutrallCell.Invader = parent;
        Cell.CreateCell.Invoke(neutrallCell);
       
        createdCells.Add(neutrallCell);
        return neutrallCell;
    }
}
