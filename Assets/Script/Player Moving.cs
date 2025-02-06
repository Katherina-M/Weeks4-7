using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour
{
    public GameObject coffee;
    public GameObject chatBubblePos;
    public float steerSpeed= 0.01f;
    public float moveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coffee<GetComponent>
        coffee = transform.position;
        
        float activeDistance = transform.position - coffeePos;




        if ()
        {

        }

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(steerAmount, moveAmount, 0);
    }
}
