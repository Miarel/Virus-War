using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralCell : Cell
{
    public override void Capture(Cell parent)
    {
        this.Invader = parent;
        CaptureCell.Invoke(this);
        CellCreator.CreateCellAt(gameObject.transform.position,parent);

        Destroy(gameObject);
    }

    public override void TakeDamage(Cell sender, float damage)
    {
       Capture(sender);
    }
}
