using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public static float volumeSounds = 1f;// ��������� ������
    public static float volumeMusic = 0.2f;// ��������� ������

    /// <summary>
    /// ��������������� ������
    /// </summary>
    /// <param name="sound">����</param>
    public void PlaySounds(AudioSource sound)
    {
        sound.volume = volumeSounds;
        sound.Play();
    }

    /// <summary>
    /// ��������������� ������
    /// </summary>
    /// <param name="music">������</param>
    public void PlayMusic(AudioSource music)
    {
        music.volume = volumeMusic;
        music.Play();
    }

    /// <summary>
    /// ��������� ��������������� �����
    /// </summary>
    /// <param name="sound">����</param>

    public void StopAudio(AudioSource sound)
    {
        sound.Stop();
    }

}
