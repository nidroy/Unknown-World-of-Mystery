using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLocation : MonoBehaviour
{
    //public Animator interfaceAnim;
    public Player player;

    public void HideBriefing()
    {
        //interfaceAnim.SetBool("isShow", true);
        player.isMove = true;
    }
}
