using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screensaver : MonoBehaviour
{
    public GameObject loadObject;// объект загрузки
    public GameObject closeObject;// объект закрытия

    public Animator gatesAnim;// анимации ворот

    public AudioManager audioManager;// менеджер звуков
    public AudioSource music;// музыка

    /// <summary>
    /// применение настроек
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
    /// проигрывание начальной заставки игры
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
