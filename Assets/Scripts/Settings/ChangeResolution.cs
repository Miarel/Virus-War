using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResolution : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    void Start()
    {
    }
    public void SetScreenMode()
    {
        Screen.fullScreen = fullScreenToggle.isOn;
    }
    public void SetResolution()
    {
        var resolutionNum = resolutionDropdown.value;
        switch (resolutionNum)
        {
            case 0:
                Screen.SetResolution(3840,2160, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1920,1080, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1680,1050, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(1600,1024, Screen.fullScreen);
                break;
            case 4:
                Screen.SetResolution(1600,900, Screen.fullScreen);
                break;
            case 5:
                Screen.SetResolution(1440,900, Screen.fullScreen);
                break;
            case 6:
                Screen.SetResolution(1366,768, Screen.fullScreen);
                break;
            case 7:
                Screen.SetResolution(1360,768, Screen.fullScreen);
                break;
            case 8:
                Screen.SetResolution(1280,960, Screen.fullScreen);
                break;
            case 9:
                Screen.SetResolution(1280,800, Screen.fullScreen);
                break;
            case 10:
                Screen.SetResolution(1152,864, Screen.fullScreen);
                break;
            case 11:
                Screen.SetResolution(1024,768, Screen.fullScreen);
                break;
        }
    }
}
