using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TicTacToe : MonoBehaviour
{
    public Animator ticTacToeAnim;
    public Dialogue dialogue;

    public Sprite playerIcon;
    public Sprite skeletonIcon;

    public Image[] icon;
    public Button[] button;
    public EventTrigger[] trigger;

    private int[] arrayCells = new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1 };

    private bool isPlayerMove = false;
    private bool isSkeletonMove = true;

    public void StartTicTacToe()
    {
        ticTacToeAnim.SetBool("isShow", true);
    }

    public void EndTicTacToe()
    {
        ticTacToeAnim.SetBool("isShow", false);
        dialogue.skeletonDialog.text = "Not a bad game. Shall we play again?";
        dialogue.ShowDialog();
    }

    public void CellSelection(int cellNumber)
    {
        if (isPlayerMove && arrayCells[cellNumber] == 1)
        {
            icon[cellNumber].sprite = playerIcon;
            icon[cellNumber].gameObject.SetActive(true);
            button[cellNumber].enabled = false;
            trigger[cellNumber].enabled = false;
            arrayCells[cellNumber] = 0;
            isPlayerMove = false;
            isSkeletonMove = true;
        }
    }


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
            int cellNumber = Random.Range(0, 9);
            if (arrayCells[cellNumber] == 1)
            {
                isSkeletonMove = false;
                StartCoroutine(SkeletonMove(cellNumber));
            }
        }
    }

    private IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(0.4f);
        UpdatingField();
        EndTicTacToe();
    }

    private IEnumerator SkeletonMove(int cellNumber)
    {
        yield return new WaitForSeconds(0.2f);

        icon[cellNumber].sprite = skeletonIcon;
        icon[cellNumber].gameObject.SetActive(true);
        button[cellNumber].enabled = false;
        trigger[cellNumber].enabled = false;
        arrayCells[cellNumber] = 2;
        isPlayerMove = true;
    }

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

    private bool Victory(int result)
    {
        if (arrayCells[0] + arrayCells[1] + arrayCells[2] == result)
            return true;
        else if (arrayCells[3] + arrayCells[4] + arrayCells[5] == result)
            return true;
        else if(arrayCells[6] + arrayCells[7] + arrayCells[8] == result)
            return true;
        else if(arrayCells[0] + arrayCells[3] + arrayCells[6] == result)
            return true;
        else if(arrayCells[1] + arrayCells[4] + arrayCells[7] == result)
            return true;
        else if(arrayCells[2] + arrayCells[5] + arrayCells[8] == result)
            return true;
        else if(arrayCells[0] + arrayCells[4] + arrayCells[8] == result)
            return true;
        else if(arrayCells[2] + arrayCells[4] + arrayCells[6] == result)
            return true;
        return false;
    }

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
