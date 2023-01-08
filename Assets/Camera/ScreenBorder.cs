using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorder : MonoBehaviour
{
    // Width of the screen border
    // Width of the screen border
    public float borderWidth = 10f;

    // Height of the screen border
    public float borderHeight = 5f;

    // Color of the screen border
    public Color borderColor = Color.red;

    void OnDrawGizmos()
    {
        // Calculate the screen borders
        float left = -Screen.width / 2 + borderWidth / 2;
        float right = Screen.width / 2 - borderWidth / 2;
        float top = Screen.height / 2 - borderHeight / 2;
        float bottom = -Screen.height / 2 + borderHeight / 2;

        // Draw the screen border
        Gizmos.color = borderColor;
        Gizmos.DrawLine(new Vector3(left, top, 0), new Vector3(right, top, 0));
        Gizmos.DrawLine(new Vector3(right, top, 0), new Vector3(right, bottom, 0));
        Gizmos.DrawLine(new Vector3(right, bottom, 0), new Vector3(left, bottom, 0));
        Gizmos.DrawLine(new Vector3(left, bottom, 0), new Vector3(left, top, 0));
    }
}
