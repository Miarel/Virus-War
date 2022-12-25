using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float score;
    [SerializeField] private Cell.CellState state;
    Cell[] cells;
    // Start is called before the first frame update
    void Start()
    {
        cells = GameObject.FindObjectsOfType<Cell>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Cell cell in cells)
        {
            if (cell.currentState == state) score += cell.tempDNA;
        }
        scoreText.text = Mathf.RoundToInt(score).ToString();
        score = 0;
    }
}
