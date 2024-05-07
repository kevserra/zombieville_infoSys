using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainLayerSort : MonoBehaviour
{
    // Reference to the Canvas
    public Canvas canvas;

    // Reference to the Particle System
    public ParticleSystem rainSystem;

    void Start()
    {
        // Set the Particle System's sorting layer to be in front of the canvas
        var renderer = rainSystem.GetComponent<ParticleSystemRenderer>();
        renderer.sortingLayerName = canvas.sortingLayerName;
        renderer.sortingOrder = canvas.sortingOrder + 10; // Adjust this value as needed
    }
}
