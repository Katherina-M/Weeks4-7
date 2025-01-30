using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChimeClock : MonoBehaviour
{
    public float rotateAngle = 30f;
    public float rotateSpeed = 0.01f;
    public AudioSource chimeAudio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -rotateAngle * rotateSpeed);
        if (rotateAngle % 30 == 0)
        {
            chimeAudio.Play();
        }
    }
}
