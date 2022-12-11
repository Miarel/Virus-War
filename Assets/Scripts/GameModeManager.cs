using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    [SerializeField] int gameModeIndex;
    public TextMeshProUGUI description;
    public void ChangeIndex(int index)
    {
        gameModeIndex = index;
    }
    void Update()
    {
        switch (gameModeIndex)
        {
            case 0:
                description.text = "tutorial";
                break;
            case 1:
                description.text = "gm1";
                break;
            case 2:
                description.text = "gm2";
                break;
            case 3:
                description.text = "gm3";
                break;
        }
    }
    public void OpenGameMode()
    {
        switch (gameModeIndex)
        {
            case 0:
                SceneManager.LoadScene("SampleScene");
                break;
            case 1:
                SceneManager.LoadScene("SampleScene");
                break;
            case 2:
                SceneManager.LoadScene("SampleScene");
                break;
            case 3:
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }
}
