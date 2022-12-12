using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
//namespace Tutorial
//{
public class TutorialCell : MonoBehaviour
{
    public static event System.Action<Transform> VirusSpawned;
    public static event System.Action<GameObject> StateChanged;
    [SerializeField] private TextMeshPro score;
    [SerializeField] public int capOfDNA;
    [SerializeField] private int viability;
    public float reproductionSpeed;
    [SerializeField] private float respawnTime;
    private int amountOfDNA = 20;
    public float tempDNA;
    private Ray currentRay;
    private RaycastHit2D currentHit;
    private bool currentCoroutineState = false;
    [SerializeField] public bool isSelected = false;
    [SerializeField] private GameObject virusPrefab;
    public enum CellState {Ally,Enemy,Neutral};
    [SerializeField] public CellState currentState;
    
    
    private void Start() 
    {
        
    }

    void Update()
    {
       CheckStatus();
       ReproductiveGrowth();   
    }
     

    private void OnEnable() {
        TutorialHandler.LeftClicked += SelectAllyCell;
        TutorialHandler.RightClicked += DeselectAllyCell;
        TutorialHandler.LeftClicked += GetEnemyCellHitPosition;
        TutorialHandler.LeftClicked += ClickedOnEnemyCell;
        Virus.TouchedTutorialCell += TakeDamage;
    }


    public void ReproductiveGrowth()
    {
        if (tempDNA <= capOfDNA && currentState != CellState.Neutral)
        {
            tempDNA += reproductionSpeed * Time.deltaTime;
            amountOfDNA = Mathf.RoundToInt(tempDNA);
            score.text = amountOfDNA.ToString();
        }
        
    } 

    public void TutorialSpawnVirus(Ray ray, RaycastHit2D hit)
    {
        if(currentState == CellState.Ally)
        {
            Transform currentPosition = gameObject.transform;
            if (hit.collider != null && hit.collider.TryGetComponent<TutorialCell>(out TutorialCell cell)) 
            {   
                if (cell.currentState == TutorialCell.CellState.Enemy || cell.currentState == TutorialCell.CellState.Neutral)
                {
                    GameObject virus = Instantiate(virusPrefab,currentPosition.position,currentPosition.rotation) as GameObject; 
                    tempDNA -= 1;
                    amountOfDNA = Mathf.RoundToInt(tempDNA);
                    score.text = amountOfDNA.ToString();
                    VirusSpawned?.Invoke(hit.transform);
                }
            }
        }
    }


    private void CheckStatus()
    {
        if(isSelected)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;  
        }
        if(currentState == CellState.Enemy)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if(currentState == CellState.Neutral)
        {
           gameObject.GetComponent<SpriteRenderer>().color = Color.yellow; 
        }
    }

    private void SelectAllyCell(Ray ray, RaycastHit2D hit)
    {
        if (hit.collider != null && hit.collider.TryGetComponent<TutorialCell>(out var cell)) 
        {
            if (currentState == CellState.Ally)
                cell.isSelected = true;
        }  
    }

    private void DeselectAllyCell(Ray ray, RaycastHit2D hit)
    {
        if (hit.collider != null && hit.collider.TryGetComponent<TutorialCell>(out var cell) && currentState == CellState.Ally) 
        {
            if (currentState == CellState.Ally)
                cell.isSelected = false;
        }  
    }

    IEnumerator SpawnVirusCoroutine()
    {
        while(isSelected && tempDNA - 1 > 0)
        {
            currentCoroutineState = true;
            TutorialSpawnVirus(currentRay,currentHit);
            yield return new WaitForSeconds(respawnTime);
            currentCoroutineState = false;
        }
    }

    private void GetEnemyCellHitPosition(Ray ray, RaycastHit2D hit)
    {
        if(hit.collider != null && hit.collider.TryGetComponent<TutorialCell>(out var cell))
        {
            if (cell.currentState == CellState.Enemy)
            {
                currentRay = ray;
                currentHit = hit;
            }
            if (cell.currentState == CellState.Neutral)
            {
                currentRay = ray;
                currentHit = hit;
            }
        }
    }

    private void ClickedOnEnemyCell(Ray ray, RaycastHit2D hit)
    {
        if(hit.collider != null && 
        hit.collider.TryGetComponent<TutorialCell>(out var cell))
        {
            if (!currentCoroutineState)
                StartCoroutine(SpawnVirusCoroutine());
        }
    }

    private void TakeDamage(float damage, TutorialCell cell)
    {
        if (this != cell) return;
        if(tempDNA - damage <= 0 )
        {
            StateChanged?.Invoke(gameObject);
            tempDNA = 0;
            amountOfDNA = Mathf.RoundToInt(tempDNA);
            score.text = amountOfDNA.ToString();
            
        }
        else
        {  
            tempDNA -= damage;
            amountOfDNA = Mathf.RoundToInt(tempDNA);
            score.text = amountOfDNA.ToString();
        }
    }

    private void OnDisable() 
    {
        TutorialHandler.LeftClicked -= SelectAllyCell;
        TutorialHandler.RightClicked -= DeselectAllyCell;
        TutorialHandler.LeftClicked -= GetEnemyCellHitPosition;
        TutorialHandler.LeftClicked -= ClickedOnEnemyCell;
        Virus.TouchedTutorialCell -= TakeDamage;
    }
}
//}
