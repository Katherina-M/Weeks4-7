using UnityEngine;

public class Decting : MonoBehaviour
{
    public GameObject flower;
    public GameObject bullet;
    bool isFlowerExist;
    public float bulletSpeed = 0.1f;


    private void Update()
    {

        if (flower.transform.position != transform.position);
        {
            bool isFlowerExist = false;
            bullet.transform.position += transform.position * bulletSpeed * Time.deltaTime;
        }
    }
}
