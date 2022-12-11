using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public static event System.Action<float, Cell> TouchedCell;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Transform targetPostion;
    private bool gotTarget = true;

    private void OnEnable() 
    {
        Cell.VirusSpawned += GetTargetPosition;
    }
    
    private void Update() 
    {
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
    }

    private void MoveToCell(Transform target)
    {
        if(TryGetComponent<Virus>(out var virus))
        {
            virus.transform.position = Vector3.MoveTowards(virus.transform.position, target.position, speed * Time.deltaTime); 
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
    }
}
