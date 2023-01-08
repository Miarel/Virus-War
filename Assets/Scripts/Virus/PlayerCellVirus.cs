using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCellVirus : Virus
{
    public override void OnAllyTrigerBehaviour(GameObject gameObject)
    {
        var allyCell = gameObject.GetComponent<PlayerCell>();
        Heal(allyCell);
    }

    public override void OnEnemyTrigerBehaviour(GameObject gameObject)
    {
        var enemyCell = gameObject.GetComponent<EnemyCell>();
        Attack(enemyCell);  
    }

    public override bool OnCheckAlly(GameObject gameObject)
    {
        if (gameObject.GetComponent<PlayerCell>() != null) return true;
        return false;
    }

    public override bool OnCheckEnemy(GameObject gameObject)
    {
        if (gameObject.GetComponent<EnemyCell>() != null) return true;
        return false;
    }

    public override void OnNeutrallTrigerBehaviour(GameObject gameObject)
    {
        var cell = gameObject.GetComponent<Cell>();
        Attack(cell);
    }

    public override bool OnCheckNeutrall(GameObject gameObject)
    {
        if (gameObject.GetComponent<Cell>() != null) return true;
        return false;
    }
}
