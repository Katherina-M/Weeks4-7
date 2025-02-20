using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSlider : MonoBehaviour
{
    public Slider plantSlider; // Slider to select plant variation
    public PlantManager plantManager; // Reference to PlantManager
    public int numPlants = 4;

    void Start()
    {
        // Set the slider range to match the number of plants
        plantSlider.minValue = 0;
        plantSlider.maxValue = numPlants - 1; // 0 to (numPlants-1)

        // Slider value change event
        // Reference https://docs.unity3d.com/2018.3/Documentation/ScriptReference/UI.Slider-onValueChanged.html
        plantSlider.onValueChanged.AddListener(OnSliderChange);
    }

    void OnSliderChange(float value)
    {
        // Convert slider value to an integer to select plant
        // Reference https://docs.unity3d.com/540/Documentation/ScriptReference/Mathf.RoundToInt.html
        int selectedPlantIndex = Mathf.RoundToInt(value); //Round to the near int

        // Select the plant based on the slider value
        plantManager.SelectPlant(selectedPlantIndex);
    }
}
