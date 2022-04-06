using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public abstract class Location : MonoBehaviour
{
    public Animator interfaceAnim; // �������� ����������
    public Animator gatesAnim; // �������� �����

    public Player player; // �����

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
        player.isMove = true;
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    /// <param name="level">�������</param>
    public void CompleteLevel(int level)
    {
        if (completeObject.activeInHierarchy)
        {
            gatesAnim.SetBool("isClose", true);
            if (!isExitMenu)
                player.gameObject.SetActive(false);
        }
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
        GameManager.characterLevel = level;
        SceneManager.LoadScene(GameManager.characterLevel + 2);
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
        Client.SendingMessage(GameManager.username, String.Format("Save_{0}_{1}_{2}_{3}", GameManager.username, GameManager.characterName, GameManager.characterLevel, GameManager.timeInTheGame));
    }
}
