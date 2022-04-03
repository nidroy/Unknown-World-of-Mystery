using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondLocation : Location
{
    public Animator[] statueAnim;
    public Animator gatesAnim;
    public GameObject briefing;
    public GameObject trigger;
    public GameObject[] riddle;
    public SpriteRenderer door;
    public Sprite openDoor;
    private bool isStart = true;
    public static bool isOpenDoor = false;

    public bool isChoosingShape { get; set; }
    public bool isEquations { get; set; }

    private void Start()
    {
        isOpenDoor = false;
        player.Teleportation();
        isChoosingShape = false;
        isEquations = false;
        isExitMenu = false;
    }

    private void Update()
    {
        if(!briefing.activeInHierarchy && isStart)
        {
            isStart = false;
            player.EndTeleportation();
        }
        if(isChoosingShape && isEquations)
        {
            door.sprite = openDoor;
            trigger.SetActive(true);
        }
        if(!riddle[0].activeInHierarchy && isEquations)
        {
            statueAnim[0].SetBool("isOpen", true);
        }
        if (!riddle[1].activeInHierarchy && isChoosingShape)
        {
            statueAnim[1].SetBool("isOpen", true);
        }
        if (isOpenDoor)
        {
            isOpenDoor = false;
            completeObject.SetActive(true);
        }
        if (completeObject.activeInHierarchy)
        {
            gatesAnim.SetBool("isClose", true);
            if(!isExitMenu)
                player.gameObject.SetActive(false);
        }
        if (loadObject.activeInHierarchy)
        {
            if (isExitMenu)
            {
                ExitMenu();
            }
            else
            {
                GameManager.characterLevel = 2;
                SceneManager.LoadScene(GameManager.characterLevel + 2);
            }
        }
    }

    public void ShowRiddle(string name)
    {
        interfaceAnim.SetBool(name, true);
    }

    public void HideRiddle(string name)
    {
        interfaceAnim.SetBool(name, false);
    }

    public void SolveChoosingShape()
    {
        interfaceAnim.SetBool("isChoosingShape", false);
        isChoosingShape = true;
    }

    public void SolveEquations()
    {
        interfaceAnim.SetBool("isEquations", false);
        isEquations = true;
    }
}
