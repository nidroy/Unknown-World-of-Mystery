using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screensaver : MonoBehaviour
{
    public GameObject loadObject;
    public GameObject closeObject;
    public Animator gatesAnim;

    void Update()
    {
        if(closeObject.activeInHierarchy)
        {
            gatesAnim.SetBool("isClose", true);
        }
        if(loadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(1);
        }
    }
}
