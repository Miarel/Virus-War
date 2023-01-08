using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCellCreator : CellCreator
{
    public override Cell CreateCell()
    {
        var spawnPos = Vector3.one;

        return CreateCellAt(spawnPos);
    }

    public override Cell CreateCellAt(Vector3 spawnPos,Cell parent = null)
    {
        var playerCell = Instantiate(prefab, spawnPos, Quaternion.identity).AddComponent<PlayerCell>();
        playerCell.name = $"Neutrall Cell";
        playerCell.Invader = parent;

        Cell.CreateCell.Invoke(playerCell);
        createdCells.Add(playerCell);

        return playerCell;
    }
}
