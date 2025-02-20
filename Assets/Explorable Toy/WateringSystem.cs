using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringSystem : MonoBehaviour
{
    public GameObject waterDropPrefab; // Water drop prefab
    public PlantManager plantManager; // Reference to PlantManager

    void Update()
    {
        // Check for screen click
        if (Input.GetMouseButtonDown(0)) //Left click
        {
            WaterPlant();
        }
    }

    void WaterPlant()
    {
        // Reset water timer in PlantManager
        plantManager.WaterPlant();

        // Spawn water drop at mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // No z-axis
        GameObject waterDrop = Instantiate(waterDropPrefab, mousePosition, Quaternion.identity);

        // Destroy water drop after 1 second
        Destroy(waterDrop, 1f);
    }
}
