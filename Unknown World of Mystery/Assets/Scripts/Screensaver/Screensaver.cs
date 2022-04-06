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
        //if (!Process.GetProcesses().Any(p => p.ProcessName == FileManager.serverPath))
        //{
        //    Process.Start(FileManager.serverPath);
        //}
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
