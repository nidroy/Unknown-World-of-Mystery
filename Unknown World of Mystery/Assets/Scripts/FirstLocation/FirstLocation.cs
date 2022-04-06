using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLocation : Location
{
    public Animator doorAnim;

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
            doorAnim.SetBool("isOpen", true);
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
            player.StartTeleportation();
        }
        CompleteLevel(1);

    }

}
