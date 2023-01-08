using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private bool isThereEnemyCell = true;
    [SerializeField] private bool isThereAllyCell = true;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TMP_Text ally;
    [SerializeField] private TMP_Text enemy;
    public static bool isTimeEnded = false;
    private string level;
    public void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        isTimeEnded = false;
        level = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyCells();
        CheckAllyCells();
        if (!isThereEnemyCell) 
        {
            winPanel.SetActive(true);
            PlayerPrefs.SetInt(level, 1);

        }
        if (!isThereAllyCell) 
        {
            losePanel.SetActive(true);
            PlayerPrefs.SetInt("botWin", 1);
        }
    }
    void CheckEnemyCells()
    {
        Cell[] cells  = FindObjectsOfType<Cell>();
        foreach (var cell in cells)
        {
            if (cell is EnemyCell) 
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
            if (cell is PlayerCell) 
            {
                isThereAllyCell = true;
                break;
            }
            else isThereAllyCell = false;
            //isThereAllyCell = cell is PlayerCell? true : false;
        }
    }
    public void TimeResult()
    {
        if (float.TryParse(ally.text, out float allyf) && float.TryParse(enemy.text, out float enemyf))
        {
            Time.timeScale = 0;
            if (float.Parse(ally.text) >= float.Parse(enemy.text)) 
            {
                winPanel.SetActive(true);
                PlayerPrefs.SetInt(level, 1);
            }
            else 
            {
                losePanel.SetActive(true);
                PlayerPrefs.SetInt("botWin", 1);
            }
        }
    }
}
