using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WateringMessage : MonoBehaviour
{
    public Text messageText; // Reference to the UI Text
    public WateringSystem wateringSystem; // Reference to WateringSystem
    public PlantManager plantManager; // Reference to PlantManager

    private float timer = 0f;
    private bool messageVisible = false;

    void Start()
    {
        messageText.gameObject.SetActive(false); // Hide message at start
    }

    void Update()
    {
        if (plantManager.HasActivePlant()) // Only check if a plant exists
        {
            if (Input.GetMouseButtonDown(0)) // If player clicks, hide message
            {
                messageText.gameObject.SetActive(false);
                timer = 0f; // Reset timer
                messageVisible = false;
            }
            else // If no click detected, start timer
            {
                timer += Time.deltaTime;

                if (timer >= 1f && !messageVisible) // Show message after 1 sec
                {
                    messageText.gameObject.SetActive(true);
                    messageVisible = true;
                }
            }
        }
        else
        {
            messageText.gameObject.SetActive(false); // Hide message if no plant exists
            timer = 0f; // Reset timer when no plant
            messageVisible = false;
        }
    }
}
