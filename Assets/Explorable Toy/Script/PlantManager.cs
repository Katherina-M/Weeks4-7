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
    // Time allowed for clicking to water the plant
    public float wateringTime = 2f; 

    GameObject currentPlant;
    int currentStage = 0;
    int currentPlantIndex = -1; //No plant selected initially
    float growthTimer = 0f;
    float wateringTimer = 0f;

    private List<List<GameObject>> allPlants = new List<List<GameObject>>();
    private bool plantIsDead = true;

    // Track clicks for watering
    private int clickCount = 0;
    private bool isInGrowthPhase = false;

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

            // Check if the plant is in the growth phase
            if (isInGrowthPhase)
            {
                wateringTimer += Time.deltaTime;

                // Check if the player has clicked enough times
                if (clickCount >= 5)
                {
                    GrowToNextStage();
                    isInGrowthPhase = false; // Exit growth phase
                    clickCount = 0; // Reset click counter
                    wateringTimer = 0f; // Reset watering timer
                }

                // Check if the watering time has expired
                if (wateringTimer >= wateringTime)
                {
                    DestroyPlant();  // Destroy the plant if not watered in time
                    return; // Exit the Update method early
                }
            }

            // Check if the plant is ready to enter the growth phase
            if (growthTimer >= growInterval)
            {
                isInGrowthPhase = true; // Enter growth phase
                growthTimer = 0f; // Reset growth timer
                wateringTimer = 0f; // Reset watering timer
                clickCount = 0; // Reset click counter
                Debug.Log("Entered growth phase! Click 5 times to water the plant.");
            }
        }
        // Handle player input for watering (clicks or taps)
        if (Input.GetMouseButtonDown(0)) // Left mouse button or touch
        {
            RegisterClick();
        }
    }

    void RegisterClick()
    {
        if (!plantIsDead && isInGrowthPhase)
        {
            clickCount++;
            Debug.Log("Clicks: " + clickCount);

            // Optional: Provide feedback for each click (e.g., sound or visual effect)
        }
    }

    void GrowToNextStage()
    {
        if (currentStage < allPlants[currentPlantIndex].Count - 1)
        {
            currentStage++;
            UpdatePlantStage();
            Debug.Log("Plant grew to stage " + currentStage);
        }
        else
        {
            // If the plant has reached the final stage, it no longer needs to grow
            Debug.Log("Plant has reached the final stage!");
        }
    }


    void UpdatePlantStage()
    {
        // if current plant is not empty, destory it
        if (currentPlant != null)
        {
            Destroy(currentPlant);
        }

        // Recalled the new selected plant
        currentPlant = Instantiate(allPlants[currentPlantIndex][currentStage], PlantSpawnPosition.transform);
        currentPlant.transform.SetParent(PlantSpawnPosition.transform, false);

        RectTransform plantRect = currentPlant.GetComponent<RectTransform>();
        if (plantRect != null)
        {
            plantRect.anchoredPosition = Vector2.zero;
            plantRect.sizeDelta = PlantSpawnPosition.rectTransform.sizeDelta;
            plantRect.localScale = Vector3.one;
        }
    }

    void DestroyPlant()
    {
        if (currentPlant != null)
        {
            Destroy(currentPlant);
        }
        plantIsDead = true;
        Debug.Log("Plant has died due to lack of water!");
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
        wateringTimer = 0f;
        plantIsDead = false;

        UpdatePlantStage();
    }

    public void WaterPlant()
    {
        wateringTimer = 0.0f;  // Reset water timer
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
