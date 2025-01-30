using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    public SpriteRenderer sr;
    public EnableDisable script;
    public GameObject go;
    public AudioSource audioSource;
    public AudioClip clip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //sr.enabled = false;
            //script.enabled = false;
            go.SetActive(false);
            //go.activeInHierarchy // Use to test if the object is turn on or off
        }

        if (Input.GetKeyDown(KeyCode.Space))    //This only activate once each time you press the key
        {
            //sr.enabled = true;    // Turn of the Sprite Renderer of the game object, this will make the game object disappear on the screen.
            //script.enabled = true;  // Turn the script in the game object
            go.SetActive(true);     //When is a game object we need to use different code for the true of false argument.
            audioSource.PlayOneShot(clip);  //All the sound will play together
        }

        if (Input.GetKey(KeyCode.Space))    //Everytime when you press the key
        {
            if(audioSource.isPlaying == false)
            {
                //AudioSource.Play();
                //audioSource.PlayOneShot(clip);  //All the sound will play together
            }
            
        }
    }
}
