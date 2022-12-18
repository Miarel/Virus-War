using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCellCreator : CellCreator
{
    private List<PlayerCell> _creationCells = new List<PlayerCell>();

    private PlayerCell CreatePlayerCell()
    {
        var spawnPos = Vector3.one;
        var playerCell = Instantiate(prefab, spawnPos, Quaternion.identity).AddComponent<PlayerCell>();
        playerCell.name = $"playerCell";
        return playerCell;
    }

    private PlayerCell CreatePlayerCellAt(Vector3 pos)
    {
        var playerCell = Instantiate(prefab, pos, Quaternion.identity).AddComponent<PlayerCell>();
        playerCell.name = $"playerCell";
        
        return new PlayerCell();
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
