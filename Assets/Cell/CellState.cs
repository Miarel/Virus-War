using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellState : MonoBehaviour
{
    private void OnEnable() 
    {
        Cell.StateChanged += ChangeState;
        TutorialCell.StateChanged += ChangeState; 
        //88
    }

    private void ChangeState(GameObject gameObject)
    {
        
        //Cell cell = gameObject.GetComponent<Cell>();
        
        if (gameObject.TryGetComponent<Cell>(out var cell))
        {
            if(cell.currentState == Cell.CellState.Enemy || cell.currentState == Cell.CellState.Ally)
            {
                cell.currentState = Cell.CellState.Neutral;
            }
            if(cell.currentState == Cell.CellState.Neutral)
            {
                cell.currentState = Cell.CellState.Ally;
            }
        }
        if (gameObject.TryGetComponent<TutorialCell>(out var tutorialCell))
        {
            if(tutorialCell.currentState == TutorialCell.CellState.Enemy || tutorialCell.currentState == TutorialCell.CellState.Ally)
            {
                tutorialCell.currentState = TutorialCell.CellState.Neutral;
            }
            if(tutorialCell.currentState == TutorialCell.CellState.Neutral)
            {
                tutorialCell.currentState = TutorialCell.CellState.Ally;
            }
        }

    }

    private void OnDisable() 
    {
        Cell.StateChanged -= ChangeState;
        TutorialCell.StateChanged -= ChangeState;
    }
    
}
