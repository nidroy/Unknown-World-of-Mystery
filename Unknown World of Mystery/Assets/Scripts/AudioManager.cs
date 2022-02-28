using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public AudioSource sounds;// �����
    public AudioSource music;// ������
    public AudioClip clickSound;// ���� �������  
    public AudioClip hoverSound;// ���� ���������

    public static float volumeSounds;// ��������� ������
    public static float volumeMusic;// ��������� ������

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
