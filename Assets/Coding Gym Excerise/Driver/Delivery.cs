using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public bool hasPackage;
    public float PackageDelay = 1;
    public Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    public Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Crush");
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, PackageDelay);
        }
        if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package arrived!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }

}