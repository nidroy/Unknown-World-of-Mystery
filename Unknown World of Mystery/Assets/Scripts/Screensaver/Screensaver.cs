using System;
using System.Collections;
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
        if (!Process.GetProcesses().Any(p => p.ProcessName == "Unknown World of Mystery server"))
        {
            Process.Start(FileManager.serverPath);
        }
        else
        {
            string[] serverPath = Process.GetProcessesByName("Unknown World of Mystery server")[0].MainModule.FileName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            IEnumerator enumerator = serverPath.GetEnumerator();
            string pathToKey = "";
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.ToString() == "Server")
                    break;
                pathToKey += enumerator.Current.ToString() + "\\";
            }
            FileManager.pathToKey = pathToKey + "Key\\key.txt";
        }
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
