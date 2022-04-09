using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Animator dialogueAnim; // анимации диалога
    public Text skeletonDialog; // диалог скелета

    /// <summary>
    /// показать диалог
    /// </summary>
    public void ShowDialog()
    {
        dialogueAnim.SetBool("isShow", true);
    }

    /// <summary>
    /// скрыть диалог
    /// </summary>
    public void HideDialog()
    {
        dialogueAnim.SetBool("isShow", false);
    }

}
