using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public float fallSpeed = -2.5f; // Speed of falling
    public float minSize = 0.5f;   // Minimum size scale
    public float maxSize = 1.0f;   // Maximum size scale

    void Start()
    {
        // Randomize the size of the water drop
        //Reference https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Random.Range.html
        float randomSize = Random.Range(minSize, maxSize);

        transform.localScale = new Vector3(randomSize, randomSize, 1); // Scale the drop uniformly
    }

    void Update()
        {
        // Move the water drop downward
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Ensure the drop does not move horizontally and stays in 2D plane
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}