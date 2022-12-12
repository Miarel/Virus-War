using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public static event System.Action<float, Cell> TouchedCell;
    public static event System.Action<float, TutorialCell> TouchedTutorialCell;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Transform targetPostion;
    private bool gotTarget = true;

    private void OnEnable() 
    {
        Cell.VirusSpawned += GetTargetPosition;
        TutorialCell.VirusSpawned += GetTargetPosition;
    }
    
    private void Update() 
    {
        Debug.Log(targetPostion);
        MoveToCell(targetPostion);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Cell>(out var cell))
        { 
            if(cell.currentState == Cell.CellState.Enemy || cell.currentState == Cell.CellState.Neutral)
            {
                Destroy(gameObject);
                TouchedCell?.Invoke(damage, cell); 
            } 
             
        }
        if (other.TryGetComponent<TutorialCell>(out var tutorialCell))
        { 
            Debug.Log(tutorialCell);
            if(tutorialCell.currentState == TutorialCell.CellState.Enemy || tutorialCell.currentState == TutorialCell.CellState.Neutral)
            {
                Destroy(gameObject);
                TouchedTutorialCell?.Invoke(damage, tutorialCell); 
            } 
             
        }
    }

    private void MoveToCell(Transform target)
    {
        if(TryGetComponent<Virus>(out var virus))
        {
            Debug.Log(targetPostion);
            virus.transform.position = Vector3.MoveTowards(virus.transform.position, target.position, speed * Time.deltaTime); 
            Debug.Log(targetPostion);
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

    private void OnDisable() {
        Cell.VirusSpawned -= GetTargetPosition;
        TutorialCell.VirusSpawned -= GetTargetPosition;
    }
}
