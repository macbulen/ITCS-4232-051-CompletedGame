using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField] GameObject doorLeft;
    [SerializeField] GameObject doorRight;
    private Vector3 originalLeftPos;
    private Vector3 originalRightPos;
    [SerializeField] float time = 0f;
    private Vector3 leftOpenPos;
    private Vector3 rightOpenPos;
    private bool isOpen = false;
    private bool isLerp = false;
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        originalLeftPos = doorLeft.transform.position;
        originalRightPos = doorRight.transform.position;
        leftOpenPos = originalLeftPos + new Vector3(0f, 0f, 2.5f);
        rightOpenPos = originalRightPos + new Vector3(0f, 0f, -3f);
    }

    void Update()
    {
        if(isLerp)
        {
            time += Time.deltaTime;
            openDoors();
        } 
        else if (isOpen)
        {
            time += Time.deltaTime;
            closeDoors();
        }

        
    }

    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Key")
        {
            audioManager.StopSFX();
            time = 0f;
            isLerp = true;
            audioManager.PlaySFX(audioManager.doorOpen);
        }
        
        
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Key")
        {
            audioManager.StopSFX();
            time = 0f;
            isLerp = false;
            isOpen = true;
            audioManager.PlaySFX(audioManager.doorClose);
        }
    } 

    void openDoors()
    {
        //audioManager.StopSFX();
        
        doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, leftOpenPos, time/10f);
        doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, rightOpenPos, time/10f);

    }

    void closeDoors()
    {
        //audioManager.StopSFX();
        
        doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, originalLeftPos, time/10f);
        doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, originalRightPos, time/10f);
    }
}
