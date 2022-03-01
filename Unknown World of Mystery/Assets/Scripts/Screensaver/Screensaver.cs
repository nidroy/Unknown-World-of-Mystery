using UnityEngine;
using UnityEngine.SceneManagement;

public class Screensaver : MonoBehaviour
{
    public GameObject loadObject;// ������ ��������
    public GameObject closeObject;// ������ ��������

    public Animator gatesAnim;// �������� �����

    /// <summary>
    /// ���������� ��������
    /// </summary>
    void Start()
    {
        System.Diagnostics.Process.Start(Application.dataPath + "/Server/Unknown World of Mystery server.exe");
        FileManager.pathToSettings = Application.dataPath + "/Settings/settings.txt";
        Settings.GetSettings(FileManager.pathToSettings);
        ScreenManager.SetScreen();
    }

    /// <summary>
    /// ������������ ��������� �������� ����
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
