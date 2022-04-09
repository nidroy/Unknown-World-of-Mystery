using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TicTacToe : MonoBehaviour
{
    public Animator ticTacToeAnim; // �������� ��������� �������
    public Dialogue dialogue; // ������

    public Sprite playerIcon; // ������ ������
    public Sprite skeletonIcon; // ������ �������

    public Image[] icon; // ������ �� �������
    public Button[] button; // ������
    public EventTrigger[] trigger; // ������� �� �������

    private int[] arrayCells = new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // ������ �����

    private bool isPlayerMove = false; // ����� �� ��� ������?
    private bool isSkeletonMove = true; // ����� ����� �������?

    private Dictionary<int, string> victoryDictionary = new Dictionary<int, string>()
    {
        [0] = "0 1 2",
        [1] = "3 4 5",
        [2] = "6 7 8",
        [3] = "0 3 6",
        [4] = "1 4 7",
        [5] = "2 5 8",
        [6] = "0 4 8",
        [7] = "2 4 6"
    }; // ������� ������

    /// <summary>
    /// ������ �������� ������
    /// </summary>
    public void StartTicTacToe()
    {
        ticTacToeAnim.SetBool("isShow", true);
    }

    /// <summary>
    /// ��������� �������� ������
    /// </summary>
    public void EndTicTacToe()
    {
        ticTacToeAnim.SetBool("isShow", false);
        dialogue.skeletonDialog.text = "Not a bad game. Shall we play again?";
        dialogue.ShowDialog();
    }

    /// <summary>
    /// ��� ������
    /// </summary>
    /// <param name="cellNumber">����� ������</param>
    public void PlayerMove(int cellNumber)
    {
        if (isPlayerMove && arrayCells[cellNumber] == 1)
        {
            CellSelection(cellNumber, playerIcon, 0);
            isPlayerMove = false;
            isSkeletonMove = true;
        }
    }

    /// <summary>
    /// ����� ������
    /// </summary>
    /// <param name="cellNumber">����� ������</param>
    /// <param name="characterIcon">������ ���������</param>
    /// <param name="element">������� �������</param>
    private void CellSelection(int cellNumber, Sprite characterIcon, int element)
    {
        icon[cellNumber].sprite = characterIcon;
        icon[cellNumber].gameObject.SetActive(true);
        button[cellNumber].enabled = false;
        trigger[cellNumber].enabled = false;
        arrayCells[cellNumber] = element;
    }

    /// <summary>
    /// �������� � ����
    /// </summary>
    void FixedUpdate()
    {
        if (Victory(0) || Victory(6) || Draw())
        {
            isPlayerMove = true;
            isSkeletonMove = false;
            StartCoroutine(FinishGame());
        }
        else if (!isPlayerMove && isSkeletonMove)
        {
            int cellNumber = UnityEngine.Random.Range(0, 9);
            if (arrayCells[cellNumber] == 1)
            {
                isSkeletonMove = false;
                StartCoroutine(SkeletonMove(cellNumber));
            }
        }
    }

    /// <summary>
    /// ��������� ����
    /// </summary>
    /// <returns></returns>
    private IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(0.4f);
        UpdatingField();
        EndTicTacToe();
    }

    /// <summary>
    /// ��� �������
    /// </summary>
    /// <param name="cellNumber">����� ������</param>
    /// <returns></returns>
    private IEnumerator SkeletonMove(int cellNumber)
    {
        yield return new WaitForSeconds(0.2f);

        CellSelection(cellNumber, skeletonIcon, 2);
        isPlayerMove = true;
    }

    /// <summary>
    /// ���������� ����
    /// </summary>
    private void UpdatingField()
    {
        for (int i = 0; i < 9; i++)
        {
            icon[i].gameObject.SetActive(false);
            button[i].enabled = true;
            trigger[i].enabled = true;
            arrayCells[i] = 1;
        }
    }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="result">��������� �����</param>
    /// <returns>����� ��� ���</returns>
    private bool Victory(int result)
    {
        for(int i = 0; i < 8; i ++)
        {
            string[] element = victoryDictionary[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (arrayCells[int.Parse(element[0])] + arrayCells[int.Parse(element[1])] + arrayCells[int.Parse(element[2])] == result)
                return true;
        }
        return false;
    }

    /// <summary>
    /// �����
    /// </summary>
    /// <returns>����� ��� ���</returns>
    private bool Draw()
    {
        for(int i = 0; i < 9; i++)
        {
            if(arrayCells[i] == 1)
                return false;
        }
        return true;
    }
}
