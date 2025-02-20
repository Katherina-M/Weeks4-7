using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        // Get the RectTransform info
        RectTransform waterSystemRect = GetComponent<RectTransform>();

        // Spawn water drop at mouse position
        Vector2 uiPosition;

        // Reference: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/RectTransformUtility.ScreenPointToLocalPointInRectangle.html
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
        waterSystemRect, // Now using WateringSystem as the reference
        Input.mousePosition,
        null, // Null if using Screen Space - Overlay Canvas
        out uiPosition
        );

        // Instantiate water drop in UI Canvas
        GameObject waterDrop = Instantiate(waterDropPrefab, waterSystemRect);
        RectTransform waterDropRect = waterDrop.GetComponent<RectTransform>();

        if (waterDropRect != null)
        {
            waterDropRect.anchoredPosition = uiPosition; // Set position in UI space
            waterDropRect.localScale = Vector3.one; // Keep correct scale
        }

        // Destroy water drop after 1 second
        Destroy(waterDrop, 1f);
    }
}
