using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public static float volumeSounds = 1f;// громкость звуков
    public static float volumeMusic = 0.2f;// громкость музыки

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

}
