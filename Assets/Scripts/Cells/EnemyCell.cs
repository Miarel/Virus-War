using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCell : Cell
{
    override public void Update()
    {
        ReproductDna();
        Text = Mathf.RoundToInt(dnaCount).ToString();
    }
    override public void ReproductDna()
    {
        //dnaCount += reproductionSpeed * Time.deltaTime;
        dnaCount += reproductionSpeed * Time.deltaTime;
    }
}
