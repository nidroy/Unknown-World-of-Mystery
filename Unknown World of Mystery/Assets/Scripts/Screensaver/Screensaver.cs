using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screensaver : MonoBehaviour
{
    public GameObject loadObject;// ������ ��������
    public GameObject closeObject;// ������ ��������

    public Animator gatesAnim;// �������� �����

    public AudioManager audioManager;// �������� ������
    public AudioSource music;// ������

    /// <summary>
    /// ���������� ��������
    /// </summary>
    private void Start()
    {
        //if (!Process.GetProcesses().Any(p => p.ProcessName == FileManager.serverPath))
        //{
        //    Process.Start(FileManager.serverPath);
        //}
        Settings.GetSettings(FileManager.pathToSettings);
        ScreenManager.SetScreen();
        audioManager.PlayMusic(music);
    }

    /// <summary>
    /// ������������ ��������� �������� ����
    /// </summary>
    private void Update()
    {
        if(closeObject.activeInHierarchy)
        {
            gatesAnim.SetBool("isClose", true);
        }
        if(loadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(1);
        }
    }
}
