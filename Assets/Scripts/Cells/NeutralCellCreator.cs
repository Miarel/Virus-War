using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralCellCreator : CellCreator
{
    private List<NeutralCell> _creationCells = new List<NeutralCell>();

    private NeutralCell CreatePlayerCell()
    {
        var spawnPos = Vector3.one;
        var neutralCell = Instantiate(prefab, spawnPos, Quaternion.identity).AddComponent<NeutralCell>();
        neutralCell.name = $"neutralCell";

        return neutralCell;
    }

    private NeutralCell CreatePlayerCellAt(Vector3 pos)
    {
        var neutralCell = Instantiate(prefab, pos, Quaternion.identity).AddComponent<NeutralCell>();
        neutralCell.name = $"neutralCell";
        
        return new NeutralCell();
    }

    public override Cell CreateCell()
    {
        var cell = CreatePlayerCell();
        _creationCells.Add(cell);

        return cell;
    }

    public override Cell CreateCellAt(Vector3 spawnPos)
    {
        var cell = CreatePlayerCellAt(spawnPos);
        _creationCells.Add(cell);

        return cell;
    }
}
