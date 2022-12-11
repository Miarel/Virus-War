using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellState : MonoBehaviour
{
    private void OnEnable() 
    {
        Cell.StateChanged += ChangeState;
    }

    private void ChangeState(GameObject gameObject)
    {
        Cell cell = gameObject.GetComponent<Cell>();
        if(cell.currentState == Cell.CellState.Enemy || cell.currentState == Cell.CellState.Ally)
        {
            cell.currentState = Cell.CellState.Neutral;
        }
        if(cell.currentState == Cell.CellState.Neutral)
        {
            cell.currentState = Cell.CellState.Ally;
        }

    }

    private void OnDisable() 
    {
        Cell.StateChanged -= ChangeState;
    }
    
}
