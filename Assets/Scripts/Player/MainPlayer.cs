using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : Player
{
    private void Start()
    {
        UnitRepository.SelectCell.AddListener(AddSellectEffect);
        UnitRepository.UnSelectCell.AddListener(RemoveSellectEffect);
    }

    private void AddSellectEffect (Cell cell)
    {
        Debug.Log("You sellect cell" + cell.name);
        cell.GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void RemoveSellectEffect(Cell cell)
    {
        Debug.Log("You unsellect cell" + cell.name);
        cell.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void OnClickPlayerCell(Cell cell) {
        var repository = (UnitRepository as PlayerRepository);
        repository.SwitchSellectCell(cell);
    }

    public void OnClickEnemyCell(Cell cell) {
        var repository = (UnitRepository as PlayerRepository);
        
        foreach(var _cell in repository.GetSelectedCells() )
        {
            var playerCell = _cell as PlayerCell;
            playerCell.PushVirus(_cell.transform,repository.GetVirus(),cell);
        }
    }

    public void OnClickNeutrallCell(Cell cell) 
    {
        var repository = (UnitRepository as PlayerRepository);

        foreach (var _cell in repository.GetSelectedCells())
        {
            var playerCell = _cell as PlayerCell;
            playerCell.PushVirus(_cell.transform, repository.GetVirus(), cell);
        }
    }

    public void OnLongClickEnemyCell(Cell cell)
    {
        var repository = (UnitRepository as PlayerRepository);

        foreach (var _cell in repository.GetSelectedCells())
        {
            var playerCell = _cell as PlayerCell;
            playerCell.PushVirus(_cell.transform, repository.GetVirus(), cell);
        }
    }

    public void OnLongClickPlayerCell(Cell cell)
    {
        var repository = (UnitRepository as PlayerRepository);

        foreach (var _cell in repository.GetSelectedCells())
        {
            var playerCell = _cell as PlayerCell;
            playerCell.PushVirus(_cell.transform, repository.GetVirus(), cell);
        }
    }


    public void OnClickBackground(GameObject game) {}
}
