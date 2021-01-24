using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : BaseSingleton<SoundController> 
{
    
    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOnShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

	
}
