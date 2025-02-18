using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    public float steerSpeed = 0.01f;
    public float moveSpeed = 20f;
    public float boostSpeed = 30f;
    public float slowSpeed = 15f;

    GameObject boost;
    void Start()
    {
        boost = GetComponent<GameObject>();
    }

    // Update is called once per frameawd
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }

        if (collision.tag == "Slow")
        {
            moveSpeed = slowSpeed;
        }
    }
}

