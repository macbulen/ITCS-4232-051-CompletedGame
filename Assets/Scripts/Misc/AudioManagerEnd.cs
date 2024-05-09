using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerEnd : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource VoiceInHead;
    [SerializeField] AudioSource SFXSource;

    [SerializeField] AudioSource Laser;

    [Header("Audio Clip")]
    public AudioClip intro;
    public AudioClip secondArea;
    public AudioClip thirdArea;
    public AudioClip fourthArea;
    public AudioClip laser;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip end;
    public bool isPaused = false;

    private bool isPlayingVoice = false;

    private void Start()
    {
        VoiceInHead.clip = end;
        VoiceInHead.Play();
    }

    void Update()
    {
        if (!isPaused)
        {
            if (VoiceInHead.isPlaying)
            {
                isPlayingVoice = true;
            }
            else
            {
                isPlayingVoice = false;
            }
        }
        
    }

    public void PlaySFX(AudioClip clip)
    {
        if (isPaused == false)
        {
            SFXSource.PlayOneShot(clip);
        }
    }

    public void PlayLaser(AudioClip clip)
    {
        if (isPaused == false)
        {
            Laser.PlayOneShot(clip);
        }
    }

    public void PlayVoiceInHead(AudioClip clip)
    {
        if (isPaused == false)
        {
            VoiceInHead.clip = clip;
            VoiceInHead.Play();
        }
    }

    

    public void StopSFX()
    {
        SFXSource.Stop();
    }

    public void StopLaser()
    {
        Laser.Stop();
    }

    public void StopVoiceInHead()
    {
        VoiceInHead.Stop();
    }

    public void setIsPausedTrue()
    {
        isPaused = true;
        VoiceInHead.Pause();
    }

    public void setIsPausedFalse()
    {
        isPaused = false;
        if (isPlayingVoice){
           VoiceInHead.Play(); 
        }
        
    }
}
