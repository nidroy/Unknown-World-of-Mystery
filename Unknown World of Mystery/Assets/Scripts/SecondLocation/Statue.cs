using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public GameObject button; // ������ ��� �������
    public GameObject riddleIsSolved; // ������ �������� �������

    public Animator statueAnim; // �������� ������
    public Animator riddleAnim; // �������� �������

    /// <summary>
    /// �������� �������
    /// </summary>
    public void ShowRiddle()
    {
        riddleAnim.SetBool("isShow", true);
    }

    /// <summary>
    /// �������� �������
    /// </summary>
    public void HideRiddle()
    {
        riddleAnim.SetBool("isShow", false);
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    public void RaiseStatue()
    {
        statueAnim.SetBool("isRaise", true);
    }

    /// <summary>
    /// �������� ������
    /// </summary>
    /// <param name="collision">������ �������</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !riddleIsSolved.activeInHierarchy)
        {
            button.SetActive(true);
        }
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    /// <param name="collision">������ �������</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }


}
