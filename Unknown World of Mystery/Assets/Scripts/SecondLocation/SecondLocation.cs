using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLocation : MonoBehaviour
{
    public Animator interfaceAnim;
    public Player player;
    public GameObject briefing;
    public Bat bat;
    private bool isStart = true;

    public void HideBriefing()
    {
        interfaceAnim.SetBool("isShow", true);
        bat.isMove = true;
    }

    private void Start()
    {
        player.Teleportation();
    }

    private void Update()
    {
        if(!briefing.activeInHierarchy && isStart)
        {
            isStart = false;
            player.EndTeleportation();
        }
    }
}
