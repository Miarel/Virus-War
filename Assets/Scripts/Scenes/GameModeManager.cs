using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public GameObject[] modes;
    [SerializeField] int gameModeIndex;
    public TextMeshProUGUI description;
    public void ChangeIndex(int index)
    {
        if (PlayerPrefs.GetInt("isTutorialCompleted")==1) gameModeIndex = index;
    }
    public void UnlockModes()
    {
        foreach (var mode in modes)
        {
            mode.GetComponent<Image>().color= new Color(255, 255, 255, 255);
            mode.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("isTutorialCompleted") == 1) UnlockModes();
    }
    void Update()
    {
        switch (gameModeIndex)
        {
            case 0:
                description.text = "Обучение";
                break;
            case 1:
                description.text = "Первый уровень";
                break;
            case 2:
                description.text = "Второй уровень";
                break;
            case 3:
                description.text = "Третий уровень";
                break;
        }
    }
    public void OpenGameMode()
    {
        switch (gameModeIndex)
        {
            case 0:
                SceneManager.LoadScene("Tutorial");
                break;
            case 1:
                SceneManager.LoadScene("Level 1");
                break;
            case 2:
                SceneManager.LoadScene("Level 2");
                break;
            case 3:
                SceneManager.LoadScene("Level 3");
                break;
        }
    }
}
