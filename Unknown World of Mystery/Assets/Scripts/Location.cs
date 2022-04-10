using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public abstract class Location : MonoBehaviour
{
    public Animator interfaceAnim; // анимации интерфейса
    public Animator gatesAnim; // анимации ворот

    public Player player; // игрок
    public Timer timer; // таймер

    public AudioManager audioManager; // менеджер звуков

    public GameObject completeObject; // объект для завершения уровня
    public GameObject loadObject; // объект для загрузки

    public bool isExitMenu { get; set; } // выйти в меню?

    /// <summary>
    /// закрыть туториал
    /// </summary>
    public void HideTutorial()
    {
        interfaceAnim.SetBool("isShow", true);
        timer.StartTimer();
        player.isMove = true;
    }

    /// <summary>
    /// завершить уровень
    /// </summary>
    /// <param name="level">уровень</param>
    public void CompleteLevel(int level)
    {
        Complete();
        Load(level);
    }

    /// <summary>
    /// функция завершения
    /// </summary>
    private void Complete()
    {
        if (completeObject.activeInHierarchy)
        {
            gatesAnim.SetBool("isClose", true);
            timer.StopTimer();
            if (!isExitMenu)
                player.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// функция загрузки
    /// </summary>
    /// <param name="level">уровень</param>
    private void Load(int level)
    {
        if (loadObject.activeInHierarchy)
        {
            if (isExitMenu)
            {
                ExitMenu();
            }
            else
            {
                LoadLevel(level);
            }
        }
    }

    /// <summary>
    /// загрузить уровень
    /// </summary>
    /// <param name="level">уровень</param>
    private void LoadLevel(int level)
    {
        if (GameManager.isLocalAccount)
            SceneManager.LoadScene(5);
        else
        {
            GameManager.characterLevel = level;
            SaveGame();
            SceneManager.LoadScene(GameManager.characterLevel + 2);
        }
    }

    /// <summary>
    /// выход в главное меню
    /// </summary>
    private void ExitMenu()
    {
        SaveGame();
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// сохранить игру
    /// </summary>
    private void SaveGame()
    {
        if(!GameManager.isLocalAccount)
            Client.SendingMessage(GameManager.username, String.Format("Save_{0}_{1}_{2}_{3}", GameManager.username, GameManager.characterName, GameManager.characterLevel, GameManager.timeInTheGame));
    }
}
