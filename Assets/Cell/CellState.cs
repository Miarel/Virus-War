using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellState : MonoBehaviour
{
    public static event System.Action StateChangedT;
    private void OnEnable() 
    {
        Cell.StateChanged += ChangeState;
        //TutorialCell.StateChanged += ChangeState; 
        //88
    }
    private void OnDisable() 
    {
        Cell.StateChanged -= ChangeState;
        //TutorialCell.StateChanged -= ChangeState;
    }

    private void ChangeState(GameObject gameObject, Cell parentCell)
    {        
        if (gameObject.TryGetComponent<Cell>(out var cell))
        {
            if(cell.currentState == Cell.CellState.Enemy || cell.currentState == Cell.CellState.Ally)
            {
                cell.currentState = Cell.CellState.Neutral;
            }
            if(cell.currentState == Cell.CellState.Neutral && parentCell.currentState == Cell.CellState.Ally)
            {
                cell.currentState = Cell.CellState.Ally;
            }
            if(cell.currentState == Cell.CellState.Neutral && parentCell.currentState == Cell.CellState.Enemy)
            {
                cell.currentState = Cell.CellState.Enemy;
            }
        }
    }
}
