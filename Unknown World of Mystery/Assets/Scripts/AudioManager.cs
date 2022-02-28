using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public AudioSource sounds;// звуки
    public AudioSource music;// музыка
    public AudioClip clickSound;// звук нажатия  
    public AudioClip hoverSound;// звук наведения

    public static float volumeSounds;// громкость звуков
    public static float volumeMusic;// громкость музыки

    /// <summary>
    /// тригер воспроизведения звука нажатия
    /// </summary>
    public void PlayAudioClick()
    {
        sounds.volume = volumeSounds;
        sounds.PlayOneShot(clickSound);
    }

    /// <summary>
    /// тригер воспроизведения звука наведения
    /// </summary>
    public void PlayAudioHover()
    {
        sounds.volume = volumeSounds;
        sounds.PlayOneShot(hoverSound);
    }

    /// <summary>
    /// установить громкость звука
    /// </summary>
    private void Update()
    {
        music.volume = volumeMusic;
    }
}
