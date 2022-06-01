using UnityEngine;

public class FirstLocation : Location
{
    public Animator doorAnim; // анимации двери

    public AudioSource doorSound; // звук двери
    public AudioSource teleportSound; // звук телепорта

    public Skeleton skeleton; // скелет

    public GameObject openObject; // тригер открытия двери
    public GameObject teleport; // телепорт

    public static bool isOpenDoor; // дверь открыта?

    /// <summary>
    /// инициализация переменных
    /// </summary>
    private void Start()
    {
        isOpenDoor = false;
        isExitMenu = false;
    }

    /// <summary>
    /// работа локации
    /// </summary>
    private void Update()
    {
        OpenDoor();
        SkeletonAppeared();
        Teleportation();
        CompleteLevel(1);

    }

    /// <summary>
    /// функция открытия двери
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
    /// функция появления скелета
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
    /// функция телепортации
    /// </summary>
    private void Teleportation()
    {
        if (teleport.activeInHierarchy && !isExitMenu)
        {
            player.StartTeleportation();
        }
    }

    /// <summary>
    /// открыть телепорт
    /// </summary>
    public void OpenTeleport()
    {
        audioManager.PlaySounds(teleportSound);
        skeleton.OpenTeleport();
    }

}
