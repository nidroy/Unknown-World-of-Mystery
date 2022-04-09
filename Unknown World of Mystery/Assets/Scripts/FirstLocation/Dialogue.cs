using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Animator dialogueAnim; // �������� �������
    public Text skeletonDialog; // ������ �������

    /// <summary>
    /// �������� ������
    /// </summary>
    public void ShowDialog()
    {
        dialogueAnim.SetBool("isShow", true);
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    public void HideDialog()
    {
        dialogueAnim.SetBool("isShow", false);
    }

}
