using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLocation : MonoBehaviour
{
    public Animator interfaceAnim;
    public Animator houseAnim;
    public Animator gatesAnim;
    public AudioSource door;
    public Skeleton skeleton;
    public Player player;
    public AudioManager audioManager;
    public GameObject openObject;
    public GameObject teleport;
    public GameObject completeObject;
    public GameObject loadObject;

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
            SceneManager.LoadScene(3);
            GameManager.location = 2;
        }

    }

    public void HideTutorial()
    {
        interfaceAnim.SetBool("isShow", true);
        player.isMove = true;
    }
}
