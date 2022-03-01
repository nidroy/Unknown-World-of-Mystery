using UnityEngine;
using UnityEngine.SceneManagement;

public class Screensaver : MonoBehaviour
{
    public GameObject loadObject;// объект загрузки
    public GameObject closeObject;// объект закрытия

    public Animator gatesAnim;// анимации ворот

    /// <summary>
    /// применение настроек
    /// </summary>
    void Start()
    {
        System.Diagnostics.Process.Start(Application.dataPath + "/Server/Unknown World of Mystery server.exe");
        FileManager.pathToSettings = Application.dataPath + "/Settings/settings.txt";
        Settings.GetSettings(FileManager.pathToSettings);
        ScreenManager.SetScreen();
    }

    /// <summary>
    /// проигрывание начальной заставки игры
    /// </summary>
    void Update()
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
