using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Achievments : MonoBehaviour
{
    public GameObject[] achPicture;
    public TextMeshProUGUI[] achDescription;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("isTutorialCompleted")==1) 
        {
            achPicture[0].GetComponent<Image>().color = new Color(255,255,255,255);
            achDescription[0].color = new Color(255,255,255,255);
        }
        if (PlayerPrefs.GetInt("Level 1")==1) 
        {
            achPicture[1].GetComponent<Image>().color = new Color(255,255,255,255);
            achDescription[1].color = new Color(255,255,255,255);
        }
        if (PlayerPrefs.GetInt("Level 2")==1) 
        {
            achPicture[2].GetComponent<Image>().color = new Color(255,255,255,255);
            achDescription[2].color = new Color(255,255,255,255);
        }
        if (PlayerPrefs.GetInt("Level 3")==1) 
        {
            achPicture[3].GetComponent<Image>().color = new Color(255,255,255,255);
            achDescription[3].color = new Color(255,255,255,255);
        }
        if (PlayerPrefs.GetInt("botWin")==1) 
        {
            achPicture[4].GetComponent<Image>().color = new Color(255,255,255,255);
            achDescription[4].color = new Color(255,255,255,255);
        }   
    }
}
