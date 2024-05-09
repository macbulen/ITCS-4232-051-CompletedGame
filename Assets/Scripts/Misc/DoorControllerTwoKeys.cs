using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class DoorControllerTwoKeys : MonoBehaviour
{
    [SerializeField] GameObject doorLeft;
    [SerializeField] GameObject doorRight;
    private Vector3 originalLeftPos;
    private Vector3 originalRightPos;
    [SerializeField] float time = 0f;
    private Vector3 leftOpenPos;
    private Vector3 rightOpenPos;

    public bool keyOne = false;
    public bool keyTwo = false;
    //private GameObject gameKeyOne;
    //private GameObject gameKeyTwo;

    public DoorTriggerKey gameKeyOne;
    public DoorTriggerKey gameKeyTwo;
    

    void Awake()
    {
        
        //gameKeyOne = GameObject.Find("TeleportField1");
        //gameKeyTwo = GameObject.Find("TeleportField2");
        originalLeftPos = doorLeft.transform.position;
        originalRightPos = doorRight.transform.position;
        leftOpenPos = originalLeftPos + new Vector3(0f, 0f, 2.5f);
        rightOpenPos = originalRightPos + new Vector3(0f, 0f, -3f);
    }

    void Update()
    {
        keyOne = gameKeyOne.key;
        keyTwo = gameKeyTwo.key;
        
        if(keyOne && keyTwo)
        {
            
            time = 0f;
            time += Time.deltaTime;
            OpenDoors();
        } 
        else
        {
            time = 0f;
            time += Time.deltaTime;
            CloseDoors();
        }

        
    }

    void OpenDoors()
    {
        
        doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, leftOpenPos, time/2f);
        doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, rightOpenPos, time/2f);

    }

    void CloseDoors()
    {
        
        doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, originalLeftPos, time/2f);
        doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, originalRightPos, time/2f);
    }
}
