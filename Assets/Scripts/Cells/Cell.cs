using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Cell : MonoBehaviour,Attackable,Capturable
{
    public static UnityEvent<Cell> CreateCell = new UnityEvent<Cell>();

    public static UnityEvent<Cell> CaptureCell = new UnityEvent<Cell>();

    protected List<CellSkill> _cellsSkill;

    public CellCreator CellCreator;

    public Cell Invader;

    public abstract void TakeDamage(Cell sender, float damage);
    public abstract void Capture(Cell cell);
}
