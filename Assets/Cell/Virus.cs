using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
public static event System.Action<float, Cell, Cell> TouchedEnemyCell;
public static event System.Action<float, Cell, Cell> TouchedEnemyCellDmg;
public static event System.Action TouchedAllyCell;
[SerializeField] private float speed;
[SerializeField] private float damage;
private Transform targetPostion;
private bool gotTarget = true;
private Cell parentCell;
private bool gotParent = true;

private void OnEnable()
{
Cell.VirusSpawned += GetTargetPosition;
Cell.CellSpawnedVirus += GetParentCell;
Bot.VirusSpawned += GetTargetPosition;
Bot.CellSpawnedVirus += GetParentCell;
Bullet.TouchedVirus += TouchedBullet;
}

private void Update()
{
    MoveToCell(targetPostion);
}

void OnTriggerEnter2D(Collider2D other)
{
if (other.TryGetComponent<Cell>(out var cell))
{
    if (parentCell.currentState == Cell.CellState.Ally)
            {
                if(cell.currentState == Cell.CellState.Enemy || cell.currentState == Cell.CellState.Neutral)
                {
                    Destroy(gameObject);
                    TouchedEnemyCell?.Invoke(damage, cell, parentCell);
                }
                if(cell != parentCell && Cell.CellState.Ally == cell.currentState)
                {
                    Destroy(gameObject);
                    TouchedAllyCell?.Invoke();
                }
            }
    else if(parentCell.currentState == Cell.CellState.Enemy)
    {
        if(cell.currentState == Cell.CellState.Ally || cell.currentState == Cell.CellState.Neutral)
            {
                Destroy(gameObject);
                TouchedEnemyCell?.Invoke(damage, cell, parentCell); 
            }
            if(cell != parentCell && Cell.CellState.Enemy == cell.currentState)
            {
                Destroy(gameObject);
                TouchedAllyCell?.Invoke();
            }
        }
    }
}

private void MoveToCell(Transform target)
{
    if(TryGetComponent<Virus>(out var virus))
    {
        virus.transform.position = Vector3.MoveTowards(virus.transform.position, target.position, speed * Time.deltaTime);
    }
}

private void GetTargetPosition(Transform target)
{
if (gotTarget)
{
targetPostion = target;
gotTarget = false;
}

}

private void GetParentCell(Cell cell)
{
    if (gotParent) 
    {
        parentCell = cell;
        gotParent = false;
    }

}

private void TouchedBullet(Virus virus)
{
if(this == virus)
Destroy(gameObject);
}


private void OnDisable()
{
Cell.VirusSpawned -= GetTargetPosition;
Cell.CellSpawnedVirus -= GetParentCell;
Bullet.TouchedVirus -= TouchedBullet;
Bot.CellSpawnedVirus -= GetParentCell;
Bot.VirusSpawned -= GetTargetPosition;
}
}