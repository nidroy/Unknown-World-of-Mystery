using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TicTacToe : MonoBehaviour
{
    public Animator ticTacToeAnim; // анимации крестиков ноликов
    public Dialogue dialogue; // диалог

    public Sprite playerIcon; // иконка игрока
    public Sprite skeletonIcon; // иконка скелета

    public Image[] icon; // иконки на кнопках
    public Button[] button; // кнопки
    public EventTrigger[] trigger; // тригеры на кнопках

    private int[] arrayCells = new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // массив €чеек

    private bool isPlayerMove = false; // будет ли ход игрока?
    private bool isSkeletonMove = true; // будет лиход скелета?

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
    }; // словарь победы

    /// <summary>
    /// начать крестики нолики
    /// </summary>
    public void StartTicTacToe()
    {
        ticTacToeAnim.SetBool("isShow", true);
    }

    /// <summary>
    /// закончить крестики нолики
    /// </summary>
    public void EndTicTacToe()
    {
        ticTacToeAnim.SetBool("isShow", false);
        dialogue.skeletonDialog.text = "Not a bad game. Shall we play again?";
        dialogue.ShowDialog();
    }

    /// <summary>
    /// ход игрока
    /// </summary>
    /// <param name="cellNumber">номер €чейки</param>
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
    /// выбор €чейки
    /// </summary>
    /// <param name="cellNumber">номер €чейки</param>
    /// <param name="characterIcon">иконка персонажа</param>
    /// <param name="element">элемент массива</param>
    private void CellSelection(int cellNumber, Sprite characterIcon, int element)
    {
        icon[cellNumber].sprite = characterIcon;
        icon[cellNumber].gameObject.SetActive(true);
        button[cellNumber].enabled = false;
        trigger[cellNumber].enabled = false;
        arrayCells[cellNumber] = element;
    }

    /// <summary>
    /// действи€ в игре
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
    /// закончить игру
    /// </summary>
    /// <returns></returns>
    private IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(0.4f);
        UpdatingField();
        EndTicTacToe();
    }

    /// <summary>
    /// ход скелета
    /// </summary>
    /// <param name="cellNumber">номер €чейки</param>
    /// <returns></returns>
    private IEnumerator SkeletonMove(int cellNumber)
    {
        yield return new WaitForSeconds(0.2f);

        CellSelection(cellNumber, skeletonIcon, 2);
        isPlayerMove = true;
    }

    /// <summary>
    /// обновление пол€
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
    /// победа
    /// </summary>
    /// <param name="result">результат суммы</param>
    /// <returns>будет или нет</returns>
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
    /// ничь€
    /// </summary>
    /// <returns>будет или нет</returns>
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
