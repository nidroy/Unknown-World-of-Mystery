using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public AudioSource sounds;
    public AudioSource music;
    public AudioClip clickSound;  
    public AudioClip hoverSound;

    public static float volumeSounds;
    public static float volumeMusic;

    public void PlayAudioClick()
    {
        sounds.volume = volumeSounds;
        sounds.PlayOneShot(clickSound);
    }

    public void PlayAudioHover()
    {
        sounds.volume = volumeSounds;
        sounds.PlayOneShot(hoverSound);
    }

    private void Update()
    {
        music.volume = volumeMusic;
    }
}
