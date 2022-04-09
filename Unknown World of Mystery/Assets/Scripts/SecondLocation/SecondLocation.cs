using System.Collections;
using UnityEngine;

public class SecondLocation : Location
{
    public GameObject tutorial; // ��������
    public GameObject trigger; // ������
    public GameObject[] riddleIsSolvedObject; // ������� �������� �������

    public SpriteRenderer door; // �����
    public Sprite openDoor; // ������ �������� �����
    public AudioSource doorSound; // ���� �����

    public AudioSource teleportationSound; // ���� ������������

    private bool isStart; // ������ �������?
    private bool isOpenDoor; // ������� �� �����?

    public static bool is�omplete; // ���������� �������

    /// <summary>
    /// ������������� ����������
    /// </summary>
    private void Start()
    {
        isStart = true;
        isOpenDoor = false;
        is�omplete = false;
        isExitMenu = false;
        player.StartTeleportation();
    }

    /// <summary>
    /// ������ �������
    /// </summary>
    private void Update()
    {
        Teleportation();
        OpenDoor();
        �omplete();
        CompleteLevel(2);
    }

    /// <summary>
    /// ������� �������� �����
    /// </summary>
    private void OpenDoor()
    {
        if(riddleIsSolvedObject[0].activeInHierarchy && riddleIsSolvedObject[1].activeInHierarchy && !isOpenDoor)
        {
            StartCoroutine(Open());
            isOpenDoor = true;
        }
    }

    /// <summary>
    /// ������� �����
    /// </summary>
    /// <returns></returns>
    private IEnumerator Open()
    {
        yield return new WaitForSeconds(0.4f);
        audioManager.PlaySounds(doorSound);
        door.sprite = openDoor;
        trigger.SetActive(true);
    }

    /// <summary>
    /// ������� ���������� �������
    /// </summary>
    private void �omplete()
    {
        if (is�omplete)
        {
            is�omplete = false;
            completeObject.SetActive(true);
        }
    }

    /// <summary>
    /// ������� ������������
    /// </summary>
    private void Teleportation()
    {
        if (!tutorial.activeInHierarchy && isStart)
        {
            isStart = false;
            audioManager.PlaySounds(teleportationSound);
            player.EndTeleportation();
        }
    }
}
