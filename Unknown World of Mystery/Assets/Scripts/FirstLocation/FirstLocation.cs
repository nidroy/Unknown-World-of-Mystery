using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLocation : Location
{
    public Animator houseAnim;
    public Animator gatesAnim;

    public AudioSource door;

    public Skeleton skeleton;

    public GameObject openObject;
    public GameObject teleport;

    public static bool isOpenDoor;

    private void Start()
    {
        isOpenDoor = false;
        isExitMenu = false;
    }

    private void Update()
    {
        if(isOpenDoor)
        {
            houseAnim.SetBool("isOpen", true);
            audioManager.PlaySounds(door);
            isOpenDoor = false;
        }
        if(openObject.activeInHierarchy)
        {
            skeleton.gameObject.SetActive(true);
            skeleton.isMove = true;
            skeleton.direction = -1;
        }
        if (teleport.activeInHierarchy)
        {
            player.Teleportation();
        }
        if (completeObject.activeInHierarchy)
        {
            gatesAnim.SetBool("isClose", true);
        }
        if (loadObject.activeInHierarchy)
        {
            if (isExitMenu)
            {
                ExitMenu();
            }
            else
            {
                GameManager.characterLevel = 1;
                SceneManager.LoadScene(GameManager.characterLevel + 2);
            }
        }

    }

}
