using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public abstract class Location : MonoBehaviour
{
    public Animator interfaceAnim; // �������� ����������
    public Animator gatesAnim; // �������� �����

    public Player player; // �����
    public Timer timer; // ������

    public AudioManager audioManager; // �������� ������

    public GameObject completeObject; // ������ ��� ���������� ������
    public GameObject loadObject; // ������ ��� ��������

    public bool isExitMenu { get; set; } // ����� � ����?

    /// <summary>
    /// ������� ��������
    /// </summary>
    public void HideTutorial()
    {
        interfaceAnim.SetBool("isShow", true);
        timer.StartTimer();
        player.isMove = true;
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    /// <param name="level">�������</param>
    public void CompleteLevel(int level)
    {
        Complete();
        Load(level);
    }

    /// <summary>
    /// ������� ����������
    /// </summary>
    private void Complete()
    {
        if (completeObject.activeInHierarchy)
        {
            gatesAnim.SetBool("isClose", true);
            timer.StopTimer();
            if (!isExitMenu)
                player.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// ������� ��������
    /// </summary>
    /// <param name="level">�������</param>
    private void Load(int level)
    {
        if (loadObject.activeInHierarchy)
        {
            if (isExitMenu)
            {
                ExitMenu();
            }
            else
            {
                LoadLevel(level);
            }
        }
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    /// <param name="level">�������</param>
    private void LoadLevel(int level)
    {
        if (GameManager.isLocalAccount)
            SceneManager.LoadScene(5);
        else
        {
            GameManager.characterLevel = level;
            SaveGame();
            SceneManager.LoadScene(GameManager.characterLevel + 2);
        }
    }

    /// <summary>
    /// ����� � ������� ����
    /// </summary>
    private void ExitMenu()
    {
        SaveGame();
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// ��������� ����
    /// </summary>
    private void SaveGame()
    {
        if(!GameManager.isLocalAccount)
            Client.SendingMessage(GameManager.username, String.Format("Save_{0}_{1}_{2}_{3}", GameManager.username, GameManager.characterName, GameManager.characterLevel, GameManager.timeInTheGame));
    }
}
