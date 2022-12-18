using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellCreator : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    public abstract Cell CreateCell() ;
    public abstract Cell CreateCellAt(Vector3 spawnPos);
}
