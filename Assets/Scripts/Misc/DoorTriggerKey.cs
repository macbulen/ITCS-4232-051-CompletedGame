using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerKey : MonoBehaviour
{
    public bool key = false;
    public bool keyTwo;
    AudioManager audioManager;

    public DoorTriggerKey gameKeyTwo;



    void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        keyTwo = gameKeyTwo.key;
        
    }

    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Key")
        {
            key = true;
        }

        
        if (key && keyTwo)
        {
            audioManager.PlaySFX(audioManager.doorOpen);
        }

        
        
        
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Key")
        {
            key = false;
        }
    } 
}
