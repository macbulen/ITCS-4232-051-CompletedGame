using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollideScript : MonoBehaviour
{
    AudioManager audioManager;
    public float collisions = 0;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        
    }

    void OnCollisionEnter()
    {
        
        if (collisions != 0)
        audioManager.PlaySFX(audioManager.boxCollide);
        collisions++;
    }
}
