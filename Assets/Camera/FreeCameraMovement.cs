using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraMovement : MonoBehaviour
{
    // Speed of camera movement
    public float moveSpeed = 5f;

    // Bounds for the camera movement
    public Vector2 boundsMin = new Vector2(-10, -10);
    public Vector2 boundsMax = new Vector2(10, 10);

    // Distance of the border from the edges of the screen
    public float borderDistance = 10f;

    void Update()
    {
        // Check if the mouse is within the border distance from the screen edge
        if (Input.mousePosition.x < borderDistance || Input.mousePosition.x > Screen.width - borderDistance ||
            Input.mousePosition.y < borderDistance || Input.mousePosition.y > Screen.height - borderDistance)
        {

            // Calculate movement vector based on mouse direction
            Vector2 movement = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            movement *= moveSpeed * Time.deltaTime;

            // Move the camera
            transform.position += (Vector3)movement;

            // Clamp camera position to bounds
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, boundsMin.x, boundsMax.x),
                Mathf.Clamp(transform.position.y, boundsMin.y, boundsMax.y),
                transform.position.z
            );
        }

    }
}