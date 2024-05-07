using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualFollow : MonoBehaviour
{
    public float xOffset = 0f; // Manually adjust X offset
    public float yOffset = 0f; // Manually adjust Y offset
    private Camera mainCamera;

    private void Start()
    {
        // Find and store a reference to the main camera
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (mainCamera != null)
        {
            // Calculate the target position based on the camera's movement and manual offsets
            Vector3 targetPos = mainCamera.transform.position + new Vector3(xOffset, yOffset, 0f);

            // Set the game object's position to the target position
            transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
        }
    }
}


