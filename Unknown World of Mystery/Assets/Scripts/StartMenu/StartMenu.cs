using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Settings settings;// ���������
    public AudioManager audioManager;// �������� ������

    public AudioSource music;// ������

    public Animator menuAnim;// �������� ���������� ����
    public Animator gatesAnim;// �������� �����

    public GameObject messageBox;// ���� ���������
    public Text message;// ���������

    public GameObject loadObject;// ������ ��� ��������

    /// <summary>
    /// �������� ������� ���������� ����
    /// </summary>
    /// <param name="item">�������� �������� ����</param>
    public void ShowStartMenuItem(string item)
    {
        if (item == "isSettings")
            settings.UpdateSettings(Settings.GetSettings(FileManager.pathToSettings));
        menuAnim.SetBool(item, true);
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
    /// ������� ������� ���������� ����
    /// </summary>
    /// <param name="item">�������� �������� ����</param>
    public void HideStartMenuItem(string item)
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
            SceneManager.LoadScene(GameManager.characterLevel + 2);
        }
    }
}
