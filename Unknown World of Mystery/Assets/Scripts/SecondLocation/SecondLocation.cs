using System.Collections;
using UnityEngine;

public class SecondLocation : Location
{
    public GameObject tutorial; // обучение
    public GameObject trigger; // тригер
    public GameObject[] riddleIsSolvedObject; // объекты разгадки загадки

    public SpriteRenderer door; // дверь
    public Sprite openDoor; // иконка открытой двери
    public AudioSource doorSound; // звук двери

    public AudioSource teleportationSound; // звук телепортации

    private bool isStart; // запуск локации?
    private bool isOpenDoor; // открыта ли дверь?

    public static bool isСomplete; // завершение локации

    /// <summary>
    /// инициализация переменных
    /// </summary>
    private void Start()
    {
        isStart = true;
        isOpenDoor = false;
        isСomplete = false;
        isExitMenu = false;
        player.StartTeleportation();
    }

    /// <summary>
    /// работа локации
    /// </summary>
    private void Update()
    {
        Teleportation();
        OpenDoor();
        Сomplete();
        CompleteLevel(2);
    }

    /// <summary>
    /// функция открытия двери
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
    /// открыть дверь
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
    /// функция завершения локации
    /// </summary>
    private void Сomplete()
    {
        if (isСomplete)
        {
            isСomplete = false;
            completeObject.SetActive(true);
        }
    }

    /// <summary>
    /// функция телепортации
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
