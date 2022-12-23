using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private bool isThereEnemyCell = true;
    [SerializeField] private bool isThereAllyCell = true;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TMP_Text ally;
    [SerializeField] private TMP_Text enemy;
    public static bool isTimeEnded = false;
    public void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        isTimeEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyCells();
        CheckAllyCells();
        if (!isThereEnemyCell) winPanel.SetActive(true);
        if (!isThereAllyCell) losePanel.SetActive(true);
    }
    void CheckEnemyCells()
    {
        Cell[] cells  = FindObjectsOfType<Cell>();
        foreach (var cell in cells)
        {
            if (cell.currentState == Cell.CellState.Enemy) 
            {
                isThereEnemyCell = true;
                break;
            }
            else isThereEnemyCell = false;
        }
        if (isTimeEnded) TimeResult();
        else Time.timeScale = 1;
    }
    void CheckAllyCells()
    {
        Cell[] cells  = FindObjectsOfType<Cell>();
        foreach (var cell in cells)
        {
            if (cell.currentState == Cell.CellState.Ally) 
            {
                isThereAllyCell = true;
                break;
            }
            else isThereAllyCell = false;
        }
    }
    public void TimeResult()
    {
        if (float.TryParse(ally.text, out float allyf) && float.TryParse(enemy.text, out float enemyf))
        {
        Time.timeScale = 0;
        if (float.Parse(ally.text) >= float.Parse(enemy.text)) winPanel.SetActive(true);
        else losePanel.SetActive(true);
    }}
}
