using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLocation : MonoBehaviour
{
    public Animator interfaceAnim;

    public void HideTutorial()
    {
        interfaceAnim.SetBool("isShow", true);
        Movement.isMove = true;
    }
}
