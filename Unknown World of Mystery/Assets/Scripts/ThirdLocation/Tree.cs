using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject button; // ������ ��� �������
    public GameObject riddleIsSolved; // ������ �������� �������

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
