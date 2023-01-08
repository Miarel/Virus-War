using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Player
{
    private Cell targetCell;
    private int delay =0;

    void SearchTarget()
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;
        foreach(Cell cell in FindObjectsOfType<Cell>())
        {
            if (!cell.GetComponent<EnemyCell>())
            {
                float currentDistance = Vector2.Distance(transform.position, cell.transform.position);
                if (currentDistance < nearestEnemyDistance )
                {
                    targetCell = cell;
                    nearestEnemy = cell.transform;
                    nearestEnemyDistance = currentDistance;
                }
            }
        }
       
        if(nearestEnemy != null)
        {
            var repository = (UnitRepository as EnemyRepository);
            var cell = repository.GetCells().Find(cell => cell.name == this.name);
            var enemyCell = cell as EnemyCell;
            enemyCell.PushVirus(enemyCell.transform, repository.GetVirus(), targetCell);
        }
    }

    private void Update()
    {
        delay++;
        if (delay == 200) 
        {
            SearchTarget();
            delay=0;
        }
    }
}
