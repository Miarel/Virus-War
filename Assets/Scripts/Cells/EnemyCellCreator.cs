using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCellCreator : CellCreator
{

    [SerializeField] private UnitRepository unitRepository;
    [SerializeField] private bool isBot = false;
    public override Cell CreateCell()
    {
        var spawnPos = Vector3.one;

        return CreateCellAt(spawnPos);
    }

    public override Cell CreateCellAt(Vector3 spawnPos,Cell parent = null)
    {
        prefab.GetComponent<Bot>().UnitRepository = unitRepository;
        prefab.GetComponent<Bot>().enabled = isBot;
        var enemyCell = Instantiate(prefab, spawnPos, Quaternion.identity).AddComponent<EnemyCell>();
        enemyCell.name = $"Enemy X:{spawnPos.x} Y:{spawnPos.y}";
        enemyCell.Invader = parent;
        Cell.CreateCell.Invoke(enemyCell);
        
        createdCells.Add(enemyCell);
        return enemyCell;

    }
}
