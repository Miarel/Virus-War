using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
   private bool levelEnded;
   private bool isThereEnemyCell = false;
   [SerializeField] GameObject panel;


    private void OnEnable() 
    {
        CellState.StateChangedT += LevelCompleted;
    }


    public void CheckEnemyCell()
    {   
        Cell[] cells  = FindObjectsOfType<Cell>();
        foreach(Cell cell in cells)
        {
            if (cell.currentState == Cell.CellState.Enemy)
            {
               isThereEnemyCell = true;
               return;
            }
            else
            {
                isThereEnemyCell = false;
            }
        }
    }


    public void LevelCompleted()
    {
        CheckEnemyCell();
        if(!isThereEnemyCell)
        {
            panel.SetActive(true);
        }
    }

    private void OnDisable() 
    {
        CellState.StateChangedT -= LevelCompleted;
    }
}
