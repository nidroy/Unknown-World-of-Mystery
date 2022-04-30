using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Ending : MonoBehaviour
{
    public Text finalText; // ��������� �����

    public Animator gatesAnim;// �������� �����
    public GameObject loadObject;// ������ ��������

    public AudioManager audioManager; // �������� ������
    public AudioSource music;// ������

    private bool isStart; // ������ �������?

    /// <summary>
    /// ����������� ���������� ������
    /// </summary>
    private void Start()
    {
        isStart = true;
        finalText.text = "Thanks for playing!\nTime in the game:\n" + GameManager.timeInTheGame;
    }

    /// <summary>
    /// �������� �������� ����
    /// </summary>
    private void Update()
    {
        if(isStart)
        {
            StartCoroutine(PlayMusic());
            isStart = false;
        }
        if (loadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(1);
        }
    }

    /// <summary>
    /// ������� ������� ������
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(0.5f);
        audioManager.PlayMusic(music);
    }

    /// <summary>
    /// �������� ������ �������
    /// </summary>
    public void ShowListLeaders()
    {
        Client.SendingMessage(GameManager.username, String.Format("ShowListLeaders_{0}", 5));
    }

    /// <summary>
    /// ����� � ������� ����
    /// </summary>
    public void ExitMenu()
    {
        gatesAnim.SetBool("isClose", true);
    }
}
