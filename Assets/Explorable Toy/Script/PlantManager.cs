using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class PlantManager : MonoBehaviour
{
    // Plant stages lists
    public List<GameObject> daisyStages;
    public List<GameObject> moneyTreeStages;
    public List<GameObject> sunflowerStages;
    public List<GameObject> tomatoStages;

    // UI Image to display plant stages
    public Image plantDisplay;

    // Default image for plantDisplay
    public Sprite defaultPlantImage;

    // Plant spawn position 
    public Image PlantSpawnPosition;

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
    private bool plantIsDead = true;

    void Start()
    {
        allPlants.Add(daisyStages);
        allPlants.Add(moneyTreeStages);
        allPlants.Add(sunflowerStages);
        allPlants.Add(tomatoStages);

        // Set the default image for plantDisplay
        if (defaultPlantImage != null)
        {
            plantDisplay.sprite = defaultPlantImage;
        }

        // Set initial plant selection (e.g., first plant)
        currentPlantIndex = 0; // Default to the first plant
        UpdatePlantDisplayUI(); // Update the display with the initial plant's image
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
        //// Destroy current plant
        //if (currentPlant != null)
        //{
        //    Destroy(currentPlant);
        //}

        //// Instantiate the new stage from 0
        //currentPlant = Instantiate(allPlants[currentPlantIndex][currentStage], PlantSpawnPosition.transform);

        //// Set the plant's RectTransform to match the PlantSpawnPosition
        //RectTransform plantRect = currentPlant.GetComponent<RectTransform>();
        //if (plantRect != null)
        //{
        //    plantRect.anchoredPosition = Vector2.zero; // Center within PlantSpawnPosition
        //    plantRect.sizeDelta = Vector2.zero; // Match size of PlantSpawnPosition
        //}

        if (currentPlant != null)
        {
            Destroy(currentPlant);
        }

        currentPlant = Instantiate(allPlants[currentPlantIndex][currentStage], PlantSpawnPosition.transform);
        currentPlant.transform.SetParent(PlantSpawnPosition.transform, false);

        RectTransform plantRect = currentPlant.GetComponent<RectTransform>();
        if (plantRect != null)
        {
            plantRect.anchoredPosition = Vector2.zero;
            plantRect.sizeDelta = PlantSpawnPosition.rectTransform.sizeDelta;
            plantRect.localScale = Vector3.one;
        }

        Debug.Log("Spawned Plant: " + currentPlant.name + " at " + plantRect.anchoredPosition);

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

    public void UpdatePlantDisplayUI()
    {
        if (currentPlantIndex != -1)
        {
            // Get the sprite from the first stage of the selected plant
            Sprite plantSprite = allPlants[currentPlantIndex][0].GetComponent<SpriteRenderer>().sprite;

            // Update the plantDisplay UI image with the static sprite
            plantDisplay.sprite = plantSprite;
        }
        else
        {
            // If no plant is selected, set the default image
            plantDisplay.sprite = defaultPlantImage;
        }
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

    public int GetCurrentPlantIndex()
    {
        return currentPlantIndex;
    }

    public bool HasActivePlant()
    {
        return currentPlant != null && !plantIsDead;
    }
}
