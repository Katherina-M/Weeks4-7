using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    // Plant stages lists
    public List<GameObject> daisyStages;
    public List<GameObject> moneyTreeStages;
    public List<GameObject> sunflowerStages;
    public List<GameObject> tomatoStages;

    // Time interval for growth
    public float growInterval = 2f;
    // Time before plant shrinks without water
    public float waterThreshold = 5f;

    GameObject currentPlant;
    int currentStage = 0;
    int currentPlantIndex = -1; //No plant selected initially
    float growthTimer = 0f;
    float waterTimer = 0f;

    private List<List<GameObject>> allPlants = new List<List<GameObject>>();
    private bool plantIsDead = true; // Track if plant is dead

    void Start()
    {
        allPlants.Add(daisyStages);
        allPlants.Add(moneyTreeStages);
        allPlants.Add(sunflowerStages);
        allPlants.Add(tomatoStages);
    }

    void Update()
    {
        if (currentPlant != null && !plantIsDead)
        {
            growthTimer += Time.deltaTime;
            waterTimer += Time.deltaTime;

            if (growthTimer >= growInterval)
            {
                if (waterTimer < waterThreshold)
                {
                    GrowToNextStage();
                }
                else
                {
                    DestroyPlant();  // Dies without water
                }
                growthTimer = 0f;
            }
        }
    }


    void GrowToNextStage()
    {
        if (currentStage < allPlants[currentPlantIndex].Count - 1)
        {
            currentStage++;
            UpdatePlantStage();
        }
    }

    void UpdatePlantStage()
    {
        // Destroy current plant
        if (currentPlant != null)
        {
            Destroy(currentPlant);
        }

        // Instantiate the new stage from 0
        currentPlant = Instantiate(allPlants[currentPlantIndex][currentStage], Vector3.zero, Quaternion.identity);
    }

    void DestroyPlant()
    {
        if (currentPlant != null)
        {
            Destroy(currentPlant);
        }
        plantIsDead = true;
    }

    public void SelectPlant(int plantIndex)
    {
        currentPlantIndex = plantIndex;
        Debug.Log("Selected Plant: " + plantIndex);
    }

    public void GrowPlant()
    {
        if (currentPlantIndex == -1)
        {
            Debug.Log("No plant selected!");
            return;
        }

        // Reset plant properties
        currentStage = 0;
        growthTimer = 0f;
        waterTimer = 0f;
        plantIsDead = false;

        UpdatePlantStage();
    }

    public void WaterPlant()
    {
        waterTimer = 0.0f;  // Reset water timer
    }
}
