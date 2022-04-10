using System.Collections;
using UnityEngine;

public class ThirdLocation : Location
{
    public AudioSource portalSound; // ���� �������

    public static bool is�omplete; // ���������� �������

    /// <summary>
    /// ������������� ����������
    /// </summary>
    private void Start()
    {
        is�omplete = false;
    }

    /// <summary>
    /// ������ �������
    /// </summary>
    private void Update()
    {
        Teleportation();
        CompleteLevel(3);
    }

    /// <summary>
    /// ������� ������������
    /// </summary>
    private void Teleportation()
    {
        if(is�omplete)
        {
            audioManager.PlaySounds(portalSound);
            player.StartTeleportation();
            StartCoroutine(�omplete());
            is�omplete = false;
        }
    }

    /// <summary>
    /// ������� ���������� �������
    /// </summary>
    /// <returns></returns>
    private IEnumerator �omplete()
    {
        yield return new WaitForSeconds(0.4f);
        completeObject.SetActive(true);
    }
}
