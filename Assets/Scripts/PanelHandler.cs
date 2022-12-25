using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class PanelHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    void Update()
    {
        panels = GameObject.FindGameObjectsWithTag("Panel");
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log(panels);
                panels.Last().SetActive(false);
                panels = panels.SkipLast(1).ToArray();
            }
        }
    }
}
