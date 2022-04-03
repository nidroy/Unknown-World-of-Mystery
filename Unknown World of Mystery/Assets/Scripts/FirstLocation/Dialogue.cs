using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Animator dialogueAnim;
    public Skeleton skeleton;
    public Text skeletonDialog;

    public void ShowDialog()
    {
        dialogueAnim.SetBool("isShow", true);
    }

    public void HideDialog()
    {
        dialogueAnim.SetBool("isShow", false);
    }

    public void EndDialog()
    {
        HideDialog();
        skeleton.OpenTeleport();
    }
}
