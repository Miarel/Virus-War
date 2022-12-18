using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public UnitRepository UnitRepository;

    public abstract void MakeTurn(Cell selfCell,Cell enemyCell);
}
