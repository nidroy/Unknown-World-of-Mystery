using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AuthorizationMenu authorizationMenu; // меню авторизации
    public Settings settings;// настройки
    public ChooseCharacterMenu chooseCharacterMenu;// меню выбора персонажа
    public AudioManager audioManager;// менеджер звуков

    public AudioSource music;// музыка

    public Animator menuAnim;// анимации начального меню
    public Animator gatesAnim;// анимеции ворот

    public GameObject messageBox;// окно сообщений
    public Text message;// сообщение

    public GameObject loadObject;// объект для загрузки

    /// <summary>
    /// показать меню
    /// </summary>
    public void ShowMenu()
    {
        string serverResponse = authorizationMenu.LogIn();
        if (serverResponse == "user found")
        {
            menuAnim.SetBool("isMenu", true);
        }
        else
        {
            ShowMessageBox("This user does not exist.");
        }
    }

    /// <summary>
    /// показать меню выбора персонажа
    /// </summary>
    public void ShowChooseCharacter()
    {
        menuAnim.SetBool("isChooseCharacter", true);
        chooseCharacterMenu.isUpdateItems = true;
    }

    /// <summary>
    /// показать меню создания персонажа
    /// </summary>
    public void ShowCreateCharacter()
    {
        menuAnim.SetBool("isCreateCharacter", true);
    }

    /// <summary>
    /// показать настройки
    /// </summary>
    public void ShowSettings()
    {
        settings.UpdateSettings(Settings.GetSettings(FileManager.pathToSettings));
        menuAnim.SetBool("isSettings", true);
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
    /// закрыть окно сообщений
    /// </summary>
    public void HideMessageBox()
    {
        messageBox.SetActive(false);
    }

    /// <summary>
    /// закрыть элементы начального меню
    /// </summary>
    /// <param name="item">название элемента меню</param>
    public void HideStartMenuItems(string item)
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
            SceneManager.LoadScene(GameManager.location + 1);
        }
    }
}
