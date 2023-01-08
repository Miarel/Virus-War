using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameScene : Scene
{
    protected List<CellCreator> cellCreators = new List<CellCreator>();

    [SerializeField] protected List<Player> players = new List<Player>();

    [SerializeField] protected CellClickHandler cellClickHandler;
    
    [SerializeField] protected Timer timer;

    [SerializeField] protected MainPlayer mainPlayer;

    public override void Start()
    {
        Cell.CreateCell.AddListener(AddCellCreator);
        Cell.CaptureCell.AddListener(AddCellCreator);

        cellCreators.AddRange(FindObjectsOfType<CellCreator>());

        foreach (Player player in players)
        {
            foreach (CellCreator cellCreator in cellCreators)
            {
                foreach (Cell cell in cellCreator.CreatedCells())
                    player.UnitRepository.AddCell(cell);
            }
        }

        CellClickHandler.OnClickEnemyCell.AddListener(PlayerClickEnemyCell);
        CellClickHandler.OnClickPlayerCell.AddListener(PlayerClickPlayerCell);
        CellClickHandler.OnClickNeutralCell.AddListener(PlayerClickNeutrallCell);
        CellClickHandler.OnLongClickPlayerCell.AddListener(PlayerClickLongPlayerCell);
        CellClickHandler.OnLongClickEnemyCell.AddListener(PlayerClickLongEnemyCell);
        CellClickHandler.OnClickSomeObj.AddListener(PlayerClickSomeObj);
    }

    protected virtual void PlayerClickSomeObj(GameObject gameObject)
    {
        mainPlayer.OnClickBackground(gameObject);
    }

    protected virtual void PlayerClickPlayerCell(Cell cell)
    {
        mainPlayer.OnClickPlayerCell(cell);
    }

    protected virtual void PlayerClickNeutrallCell(Cell cell)
    {
        mainPlayer.OnClickNeutrallCell(cell);
    }

    protected virtual void PlayerClickEnemyCell(Cell cell)
    {
        mainPlayer.OnClickEnemyCell(cell);
    }

    protected virtual void PlayerClickLongPlayerCell(Cell cell)
    {
        mainPlayer.OnLongClickPlayerCell(cell);

    }

    protected virtual void PlayerClickLongEnemyCell(Cell cell)
    {
        mainPlayer.OnLongClickEnemyCell(cell);
    }

    public abstract void AddCellCreator(Cell cell);
}
