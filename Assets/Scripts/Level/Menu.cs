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
        SceneManager.LoadScene("LevelMenu");
    }
    public void CompleteTutorial()
    {
        PlayerPrefs.SetInt("isTutorialCompleted", 1);
    }
}
