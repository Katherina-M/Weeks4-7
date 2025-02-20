using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
        public float fallSpeed = -2.5f; // Speed of falling

        void Update()
        {
            // Move the water drop downward over time
            Vector3 falling = transform.position;
            transform.position -= falling * fallSpeed * Time.deltaTime;
        }
}