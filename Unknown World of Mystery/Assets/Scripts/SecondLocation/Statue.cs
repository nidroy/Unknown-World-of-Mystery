using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public GameObject button; // кнопка над статуей
    public GameObject riddleIsSolved; // объект разгадки загадки

    public Animator statueAnim; // анимации статуи
    public Animator riddleAnim; // анимации загадки

    /// <summary>
    /// показать загадку
    /// </summary>
    public void ShowRiddle()
    {
        riddleAnim.SetBool("isShow", true);
    }

    /// <summary>
    /// спрятать загадку
    /// </summary>
    public void HideRiddle()
    {
        riddleAnim.SetBool("isShow", false);
    }

    /// <summary>
    /// поднять статую
    /// </summary>
    public void RaiseStatue()
    {
        statueAnim.SetBool("isRaise", true);
    }

    /// <summary>
    /// показать кнопку
    /// </summary>
    /// <param name="collision">объект касания</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !riddleIsSolved.activeInHierarchy)
        {
            button.SetActive(true);
        }
    }

    /// <summary>
    /// скрыть кнопку
    /// </summary>
    /// <param name="collision">объект касания</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }


}
