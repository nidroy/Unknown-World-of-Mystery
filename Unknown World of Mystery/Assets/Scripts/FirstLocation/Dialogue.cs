using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Animator dialogueAnim;
    public Skeleton skeleton;
    public Text skeletonDialog;
    public GameObject dialogButton;
    public GameObject[] button;

    public void ShowDialog()
    {
        dialogueAnim.SetBool("isShow", true);
        dialogButton.SetActive(false);
    }

    public void HideDialog()
    {
        dialogueAnim.SetBool("isShow", false);
    }

    public void NextDialog(string dialog)
    {
        skeletonDialog.text = dialog;
        button[0].SetActive(false);
        button[1].SetActive(false);
        button[2].SetActive(true);
    }
    public void EndDialog()
    {
        dialogueAnim.SetBool("isShow", false);
        skeleton.OpenTeleport();
    }
}
