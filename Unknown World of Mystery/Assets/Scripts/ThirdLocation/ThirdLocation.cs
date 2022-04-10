using System.Collections;
using UnityEngine;

public class ThirdLocation : Location
{
    public AudioSource portalSound; // звук портала

    public static bool isСomplete; // завершение локации

    /// <summary>
    /// инициализация переменных
    /// </summary>
    private void Start()
    {
        isСomplete = false;
    }

    /// <summary>
    /// работа локации
    /// </summary>
    private void Update()
    {
        Teleportation();
        CompleteLevel(3);
    }

    /// <summary>
    /// функция телепортации
    /// </summary>
    private void Teleportation()
    {
        if(isСomplete)
        {
            audioManager.PlaySounds(portalSound);
            player.StartTeleportation();
            StartCoroutine(Сomplete());
            isСomplete = false;
        }
    }

    /// <summary>
    /// функция завершения локации
    /// </summary>
    /// <returns></returns>
    private IEnumerator Сomplete()
    {
        yield return new WaitForSeconds(0.4f);
        completeObject.SetActive(true);
    }
}
