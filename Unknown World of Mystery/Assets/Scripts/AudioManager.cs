using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public AudioSource sounds;// �����
    public AudioSource music;// ������
    public AudioClip clickSound;// ���� �������  
    public AudioClip hoverSound;// ���� ���������

    public static float volumeSounds = 1f;// ��������� ������
    public static float volumeMusic = 0.5f;// ��������� ������

    /// <summary>
    /// ������ ��������������� ����� �������
    /// </summary>
    public void PlayAudioClick()
    {
        sounds.PlayOneShot(clickSound);
    }

    /// <summary>
    /// ������ ��������������� ����� ���������
    /// </summary>
    public void PlayAudioHover()
    {
        sounds.PlayOneShot(hoverSound);
    }

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

    /// <summary>
    /// ���������� ��������� �����
    /// </summary>
    private void Update()
    {
        music.volume = volumeMusic;
        sounds.volume = volumeSounds;
    }
}
