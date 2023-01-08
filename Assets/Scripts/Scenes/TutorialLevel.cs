using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using System;
public class TutorialLevel:GameScene
{
    [SerializeField] private Player player;
    [SerializeField] private Player enemyPlayer;
    [SerializeField] protected CellCreator _enemyCellCreator;
    [SerializeField] protected CellCreator _neutralCellCreator;
    [SerializeField] protected CellCreator _playerCellCreator;
    public GameObject back;
    private bool isFirstTip = true;
    private bool isSecondTip = false;
    private bool isThirdTip = false;
    private bool isFourthTip = false;
    private bool isFifthTip = false;
    private bool isSixthTip = false;
    private bool isNeutralCreated = false;
    private bool isEnemyCreated = false;
    public TextMeshProUGUI tutorialText;
    private bool nextTip = false;
    private bool isStarted = false;
    [TextArea(3,10)]
    [SerializeField] string[] textBlock1;
    Cell cell;
    ActivityCell activityCell;
    ActivityCell neutralCapturedCell;

    public override void Start()
    {
        Name = "Tutorial";

        players.Add(player);
        players.Add(enemyPlayer);

        _playerCellCreator.CreateCellAt(new Vector3(-2, 2, 0));

        base.Start();
        cell = player.UnitRepository.GetCells()[0];
        activityCell = cell as ActivityCell;     
        activityCell.reproductionSpeed = 0;  
        mainPlayer = player as MainPlayer;
        StartCoroutine(RunTutorial());
    }

    public override void AddCellCreator(Cell cell)
    {
        switch (cell)
        {
            case PlayerCell:
                cell.CellCreator = _enemyCellCreator;
                break;


            case EnemyCell:
                cell.CellCreator = _playerCellCreator;
                break;

            case NeutralCell:
                switch (cell.Invader)
                {
                    case PlayerCell:
                        cell.CellCreator = _playerCellCreator;
                        break;


                    case EnemyCell:
                        cell.CellCreator = _enemyCellCreator;
                        break;
                }
                break;
        }
    }
    IEnumerator RunTutorial()
    {
        foreach (var tip in textBlock1)
        {
            nextTip = false;
            string sentence = tip;
            Debug.Log(sentence);
            tutorialText.text = sentence;
            yield return new WaitUntil(()=>nextTip);
        }
        EndTutorial();
    }
    public void ContinueTutorial()
    {
        nextTip = true;
    }
    
    public void EndTutorial()
    {

    }
    public override void Update()
    {
        
        activityCell.IncreaseScore();
        if (isStarted) 
        {
            neutralCapturedCell.IncreaseScore();
        }
        
        var repository = (player.UnitRepository as PlayerRepository);

        if (repository.GetSelectedCells().Count!=0 && isFirstTip)
        {
            ContinueTutorial();
            isFirstTip = false;
            isSecondTip = true;
            activityCell.reproductionSpeed = 1;
        }
        else if (isSecondTip)
        {
            if(Mathf.Round(activityCell.dnaCount) == 10)
            {
                ContinueTutorial();
                isSecondTip = false;
                isThirdTip = true;
            }
        }
        else if (isThirdTip)
        {
            if(Mathf.Round(activityCell.dnaCount) == 20)
            {
                ContinueTutorial();
                isThirdTip = false;
                isFourthTip = true;
            }
        }
        else if (isFourthTip)
        {
            if (!isNeutralCreated) 
            {
                isNeutralCreated = true;
                _neutralCellCreator.CreateCellAt(new Vector3(2, 2, 0));
            }
            if (repository.GetCells().Count==2)
            {
                var neutralCaptured = player.UnitRepository.GetCells()[1];
                neutralCapturedCell = neutralCaptured as ActivityCell;
                neutralCapturedCell.reproductionSpeed = 1; 
                isStarted = true;
                ContinueTutorial();
                Debug.Log("complete");
                isFifthTip = true;
                isFourthTip = false;
            }
        }
        else if (isFifthTip)
        {
            if (!isEnemyCreated)
            {
                isEnemyCreated = true;
                _enemyCellCreator.CreateCellAt(new Vector3(-1, -2, 0));
                var enemyCell = enemyPlayer.UnitRepository.GetCells()[0];
                var activityEnemyCell = enemyCell as ActivityCell;     
                activityEnemyCell.reproductionSpeed = 0;
                activityEnemyCell._dnaCount = 20;
            }
            if (repository.GetCells().Count==3)
            {
            isFifthTip = false;
            isSixthTip = true;
            }
        }
        else if (isSixthTip)
        {
            back.SetActive(true);
            ContinueTutorial();
        }
    }
}

