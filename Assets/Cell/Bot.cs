using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public static event System.Action<Transform> VirusSpawned;
    public static event System.Action<Cell> CellSpawnedVirus;
    public GameObject[] cells;
    Cell targetCell;
    float tempDNA;
    bool currentCoroutineState = false;
    float respawnTime=1;
    [SerializeField] private GameObject virusPrefab;
    [SerializeField] public TextMeshPro score;
    private int amountOfDNA = 20;
    private bool canSpawn = true;
    
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Cell>().currentState == Cell.CellState.Enemy){tempDNA = gameObject.GetComponent<Cell>().tempDNA;}
        SearchTarget();
    }
    void SearchTarget()
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;
        Cell cell = this.GetComponent<Cell>();
        foreach(Cell cell1 in FindObjectsOfType<Cell>())
        {
            if(cell1.currentState != Cell.CellState.Enemy){
            float currentDistance = Vector2.Distance(transform.position, cell1.transform.position);

            if (currentDistance < nearestEnemyDistance )
            {
                targetCell = cell1;
                nearestEnemy = cell1.transform;
                nearestEnemyDistance = currentDistance;
            }}
        }
        if(nearestEnemy != null && Cell.CellState.Enemy == cell.currentState)
        {
            if (!currentCoroutineState) StartCoroutine(SpawnEnemyVirusCoroutine());
        }
    }
    IEnumerator SpawnEnemyVirusCoroutine()
    {
        while(tempDNA - 1 > 0)
        {
            currentCoroutineState = true;
            spawnVirus(targetCell);
            yield return new WaitForSeconds(respawnTime);
            currentCoroutineState = false;
        }
    }

    
    public void spawnVirus(Cell cell)
    {
        
        {
            
            
            {   
                if (cell.currentState == Cell.CellState.Ally || cell.currentState == Cell.CellState.Neutral)
                {
                    GameObject virus = Instantiate(virusPrefab,gameObject.transform.position,gameObject.transform.rotation) as GameObject; 
                    tempDNA -= 1;
                    amountOfDNA = Mathf.RoundToInt(tempDNA);
                    score.text = amountOfDNA.ToString();
                    VirusSpawned?.Invoke(cell.transform);
                    CellSpawnedVirus?.Invoke(gameObject.GetComponent<Cell>());
                }
            }
        }
    }
}
