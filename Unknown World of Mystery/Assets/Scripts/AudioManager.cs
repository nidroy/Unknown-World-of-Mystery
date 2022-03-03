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
        sounds.volume = volumeSounds;
        sounds.PlayOneShot(clickSound);
    }

    /// <summary>
    /// ������ ��������������� ����� ���������
    /// </summary>
    public void PlayAudioHover()
    {
        sounds.volume = volumeSounds;
        sounds.PlayOneShot(hoverSound);
    }

    /// <summary>
    /// ���������� ��������� �����
    /// </summary>
    private void Update()
    {
        music.volume = volumeMusic;
    }
}
