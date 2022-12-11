using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GoBackward()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void OpenModeSelector()
    {
        SceneManager.LoadScene("ModeSelector");
    }
    public void OpenGameMode(int gameModeIndex)
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
