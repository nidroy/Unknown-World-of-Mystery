using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject button; // кнопка над деревом
    public GameObject riddleIsSolved; // объект разгадки загадки

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
