using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoving : MonoBehaviour
{
    float steerSpeed= 0.01f;
    float moveSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        //transform.Rotate(0, 0, -steerAmount);
        transform.Translate(steerAmount, moveAmount, 0);
    }
}
