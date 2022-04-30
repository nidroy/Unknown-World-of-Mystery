using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Ending : MonoBehaviour
{
    public Text finalText; // финальный текст

    public Animator gatesAnim;// анимации ворот
    public GameObject loadObject;// объект загрузки

    public AudioManager audioManager; // менеджер звуков
    public AudioSource music;// музыка

    private bool isStart; // запуск локации?

    /// <summary>
    /// отображение финального текста
    /// </summary>
    private void Start()
    {
        isStart = true;
        finalText.text = "Thanks for playing!\nTime in the game:\n" + GameManager.timeInTheGame;
    }

    /// <summary>
    /// загрузка главного меню
    /// </summary>
    private void Update()
    {
        if(isStart)
        {
            StartCoroutine(PlayMusic());
            isStart = false;
        }
        if (loadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(1);
        }
    }

    /// <summary>
    /// функция запуска музыки
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(0.5f);
        audioManager.PlayMusic(music);
    }

    /// <summary>
    /// показать список лидеров
    /// </summary>
    public void ShowListLeaders()
    {
        Client.SendingMessage(GameManager.username, String.Format("ShowListLeaders_{0}", 5));
    }

    /// <summary>
    /// выход в главное меню
    /// </summary>
    public void ExitMenu()
    {
        gatesAnim.SetBool("isClose", true);
    }
}
