using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitRepository : MonoBehaviour
{
    protected List<Cell> _cells;
    
    protected Virus _virus;
    
    protected List<CellSkill> _cellsSkill;
    
    protected List<VirusSkill> _virusSkills;

    public Cell SelectedCell;
}
