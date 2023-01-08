using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class UnitRepository : MonoBehaviour
{
    public static UnityEvent<Cell> SelectCell = new UnityEvent<Cell>();
    public static UnityEvent<Cell> UnSelectCell = new UnityEvent<Cell>();

    protected List<Cell> cells = new List<Cell>();
    
    protected Virus virus;
    
    protected List<VirusSkill> virusSkills = new List<VirusSkill>();

    protected List<Cell> selectedCells = new List<Cell>();

    public long GetCellsScore()  
    {
        long sum = 0;

        foreach(Cell cell in cells)
        {
            if(cell is ActivityCell)
                sum += (long) (cell as ActivityCell).dnaCount;
        }

        return sum;
    }

    public abstract List<Cell> GetCells();

    public abstract Virus GetVirus();

    public abstract void AddCell(Cell cell);

    public abstract void RemoveCell(Cell cell);
}
