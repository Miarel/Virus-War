using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private bool isDisplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        isDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayMenu()
    {
        isDisplayed = !isDisplayed;
        Menu.SetActive(isDisplayed);
    }
    public void OnDisable()
    {
        isDisplayed = false;
    }
}
