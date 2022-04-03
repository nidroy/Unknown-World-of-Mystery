using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Location : MonoBehaviour
{
    public Animator interfaceAnim;

    public Player player;

    public AudioManager audioManager;

    public GameObject completeObject;
    public GameObject loadObject;

    public bool isExitMenu { get; set; }

    public void HideTutorial()
    {
        interfaceAnim.SetBool("isShow", true);
        player.isMove = true;
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(1);
    }
}
