using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AuthorizationMenu authorizationMenu; // ���� �����������
    public Settings settings;// ���������
    public ChooseCharacterMenu chooseCharacterMenu;// ���� ������ ���������
    public AudioManager audioManager;// �������� ������

    public AudioSource music;// ������

    public Animator menuAnim;// �������� ���������� ����
    public Animator gatesAnim;// �������� �����

    public GameObject messageBox;// ���� ���������
    public Text message;// ���������

    public GameObject loadObject;// ������ ��� ��������

    /// <summary>
    /// �������� ����
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
    /// �������� ���� ������ ���������
    /// </summary>
    public void ShowChooseCharacter()
    {
        menuAnim.SetBool("isChooseCharacter", true);
        chooseCharacterMenu.isUpdateItems = true;
    }

    /// <summary>
    /// �������� ���� �������� ���������
    /// </summary>
    public void ShowCreateCharacter()
    {
        menuAnim.SetBool("isCreateCharacter", true);
    }

    /// <summary>
    /// �������� ���������
    /// </summary>
    public void ShowSettings()
    {
        settings.UpdateSettings(Settings.GetSettings(FileManager.pathToSettings));
        menuAnim.SetBool("isSettings", true);
    }

    /// <summary>
    /// �������� ���� ���������
    /// </summary>
    /// <param name="text">���������</param>
    public void ShowMessageBox(string text)
    {
        messageBox.SetActive(true);
        message.text = text;
    }

    /// <summary>
    /// ������� ���� ���������
    /// </summary>
    public void HideMessageBox()
    {
        messageBox.SetActive(false);
    }

    /// <summary>
    /// ������� �������� ���������� ����
    /// </summary>
    /// <param name="item">�������� �������� ����</param>
    public void HideStartMenuItems(string item)
    {
        if (item == "isMenu")
            GameManager.isLocalAccount = false;
        menuAnim.SetBool(item, false);
    }

    /// <summary>
    /// ������ ������ �� ����
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// ��������� ����
    /// </summary>
    public void StartGame()
    {
        menuAnim.SetBool("isStartGame", true);
        gatesAnim.SetBool("isClose", true);
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    private void Start()
    {
        audioManager.PlayMusic(music);
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    private void Update()
    {
        if(loadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(GameManager.location + 1);
        }
    }
}
