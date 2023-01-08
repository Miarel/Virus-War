using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using System;
public class Tutorial:GameScene
{
    [SerializeField] private Player player;
    [SerializeField] private Player enemyPlayer;
    [SerializeField] private int neutralsPairs;

    [SerializeField] private TMP_Text timeLable;
    [SerializeField] private TMP_Text scoreEnemyLable;
    [SerializeField] private TMP_Text scorePlayerLable;
    
    [SerializeField] protected CellCreator _enemyCellCreator;
    [SerializeField] protected CellCreator _neutralCellCreator;
    [SerializeField] protected CellCreator _playerCellCreator;

    public override void Start()
    {
        
        Name = "Tutorial";
       
        mainPlayer = player as MainPlayer;
        System.Random rng = new System.Random();

        players.Add(player);
        players.Add(enemyPlayer);

        _playerCellCreator.CreateCellAt(new Vector3(0, -3, 0));
        
        _enemyCellCreator.CreateCellAt(new Vector3(0, 3, 0));

        List<Vector2> usedCoords = new List<Vector2>();
        for (var i = 0; i < neutralsPairs; i++) 
        {
            int x, y;
        do 
        {
            x = rng.Next(-6, 7);
            y = rng.Next(-2, 3);
        } while (usedCoords.Contains(new Vector2(x, y)));
        usedCoords.Add(new Vector2(x, y));
        _neutralCellCreator.CreateCellAt(new Vector3(x, y, 0));
        _neutralCellCreator.CreateCellAt(new Vector3(-x, -y, 0));
}

        Timer.TimeLeft.AddListener(UpdateTimeLable);

        base.Start();
    }

    private void UpdateTimeLable(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeLable.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public override void Update()
    {
        foreach(Player player in players)
        {
            foreach (Cell cell in player.UnitRepository.GetCells()) 
            {
                var activityCell = cell as ActivityCell;
                activityCell.IncreaseScore();
            }

            if (player is MainPlayer)
                scorePlayerLable.text = player.UnitRepository.GetCellsScore().ToString();
            else
                scoreEnemyLable.text = player.UnitRepository.GetCellsScore().ToString();  
        }
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
}

