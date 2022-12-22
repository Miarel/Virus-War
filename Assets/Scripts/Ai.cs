using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    public static event System.Action<Ray, RaycastHit2D> LeftClicked;
    public static event System.Action<Ray, RaycastHit2D> RightClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown (0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
            LeftClicked?.Invoke(ray,hit);
        }

        if (Input.GetMouseButtonDown (1))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
            RightClicked?.Invoke(ray,hit);
        }
    }
}
