using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLocation : MonoBehaviour
{
    public Animator interfaceAnim;
    public Animator houseAnim;
    public Animator dialogueAnim;
    public AudioSource door;
    public Skeleton skeleton;
    public Player player;
    public AudioManager audioManager;
    public GameObject openObject;

    public static bool isOpenDoor;

    void Update()
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
            skeleton.ChangeDirection(-1);
        }
    }

    public void HideTutorial()
    {
        interfaceAnim.SetBool("isShow", true);
        player.isMove = true;
    }

    public void ShowDialogue(bool isShow)
    {
        dialogueAnim.SetBool("isShow", isShow);
    }
}
