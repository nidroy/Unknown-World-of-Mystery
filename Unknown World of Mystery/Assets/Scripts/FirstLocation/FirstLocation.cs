using UnityEngine;

public class FirstLocation : Location
{
    public Animator doorAnim; // �������� �����

    public AudioSource doorSound; // ���� �����
    public AudioSource teleportSound; // ���� ���������

    public Skeleton skeleton; // ������

    public GameObject openObject; // ������ �������� �����
    public GameObject teleport; // ��������

    public static bool isOpenDoor; // ����� �������?

    /// <summary>
    /// ������������� ����������
    /// </summary>
    private void Start()
    {
        isOpenDoor = false;
        isExitMenu = false;
    }

    /// <summary>
    /// ������ �������
    /// </summary>
    private void Update()
    {
        OpenDoor();
        SkeletonAppeared();
        Teleportation();
        CompleteLevel(1);
        InstallLocalization();
    }

    private void InstallLocalization()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i != 1)
            {
                locationText[i].text = Settings.localizedText[i + 15];
            }
        }
    }

    public void InstallLocalizationDialogue()
    {
        locationText[1].text = Settings.localizedText[16];
    }

    /// <summary>
    /// ������� �������� �����
    /// </summary>
    private void OpenDoor()
    {
        if (isOpenDoor)
        {
            doorAnim.SetBool("isOpen", true);
            audioManager.PlaySounds(doorSound);
            isOpenDoor = false;
        }
    }

    /// <summary>
    /// ������� ��������� �������
    /// </summary>
    private void SkeletonAppeared()
    {
        if (openObject.activeInHierarchy)
        {
            skeleton.gameObject.SetActive(true);
            skeleton.isMove = true;
            skeleton.direction = -1;
        }
    }

    /// <summary>
    /// ������� ������������
    /// </summary>
    private void Teleportation()
    {
        if (teleport.activeInHierarchy && !isExitMenu)
        {
            player.StartTeleportation();
        }
    }

    /// <summary>
    /// ������� ��������
    /// </summary>
    public void OpenTeleport()
    {
        audioManager.PlaySounds(teleportSound);
        skeleton.OpenTeleport();
    }

}
