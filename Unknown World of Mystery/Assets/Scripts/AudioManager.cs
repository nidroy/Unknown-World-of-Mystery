using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public AudioSource sounds;// звуки
    public AudioSource music;// музыка
    public AudioClip clickSound;// звук нажатия  
    public AudioClip hoverSound;// звук наведения

    public static float volumeSounds = 1f;// громкость звуков
    public static float volumeMusic = 0.5f;// громкость музыки

    /// <summary>
    /// тригер воспроизведения звука нажатия
    /// </summary>
    public void PlayAudioClick()
    {
        sounds.PlayOneShot(clickSound);
    }

    /// <summary>
    /// тригер воспроизведения звука наведения
    /// </summary>
    public void PlayAudioHover()
    {
        sounds.PlayOneShot(hoverSound);
    }

    /// <summary>
    /// воспроизведение звуков
    /// </summary>
    /// <param name="sound">звук</param>
    public void PlaySounds(AudioSource sound)
    {
        sound.volume = volumeSounds;
        sound.Play();
    }

    /// <summary>
    /// воспроизведение музыки
    /// </summary>
    /// <param name="music">музыка</param>
    public void PlayMusic(AudioSource music)
    {
        music.volume = volumeMusic;
        music.Play();
    }

    /// <summary>
    /// остановка воспроизведения звука
    /// </summary>
    /// <param name="sound">звук</param>

    public void StopAudio(AudioSource sound)
    {
        sound.Stop();
    }

    /// <summary>
    /// установить громкость звука
    /// </summary>
    private void Update()
    {
        music.volume = volumeMusic;
        sounds.volume = volumeSounds;
    }
}
