using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Settings settings;// настройки
    public AudioManager audioManager;// менеджер звуков

    public AudioSource music;// музыка

    public Animator menuAnim;// анимации начального меню
    public Animator gatesAnim;// анимеции ворот

    public GameObject messageBox;// окно сообщений
    public Text message;// сообщение

    public GameObject loadObject;// объект для загрузки

    /// <summary>
    /// показать элемент начального меню
    /// </summary>
    /// <param name="item">название элемента меню</param>
    public void ShowStartMenuItem(string item)
    {
        if (item == "isSettings")
            settings.UpdateSettings(Settings.GetSettings(FileManager.pathToSettings));
        menuAnim.SetBool(item, true);
    }

    /// <summary>
    /// показать окно сообщений
    /// </summary>
    /// <param name="text">сообщение</param>
    public void ShowMessageBox(string text)
    {
        messageBox.SetActive(true);
        message.text = text;
    }

    /// <summary>
    /// закрыть элемент начального меню
    /// </summary>
    /// <param name="item">название элемента меню</param>
    public void HideStartMenuItem(string item)
    {
        if (item == "isMenu")
            GameManager.isLocalAccount = false;
        menuAnim.SetBool(item, false);
    }

    /// <summary>
    /// кнопка выхода из игры
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// запустить игру
    /// </summary>
    public void StartGame()
    {
        menuAnim.SetBool("isStartGame", true);
        gatesAnim.SetBool("isClose", true);
    }

    /// <summary>
    /// запуск музыки
    /// </summary>
    private void Start()
    {
        audioManager.PlayMusic(music);
    }

    /// <summary>
    /// загрузить локацию
    /// </summary>
    private void Update()
    {
        if(loadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(GameManager.characterLevel + 2);
        }
    }
}
