using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public AuthorizationMenu authorizationMenu;

    public Animator menuAnim;

    public GameObject messageBox;
    public Text message;

    public void ShowMenu()
    {
        if (authorizationMenu.LogIn() == "user found")
        {
            menuAnim.SetBool("isMenu", true);
        }
        else
        {

        }
    }

    public void ShowChooseCharacter(bool isShow)
    {
        menuAnim.SetBool("isChooseCharacter", isShow);
    }

    public void ShowCreateCharacter(bool isShow)
    {
        menuAnim.SetBool("isCreateCharacter", isShow);
    }

    public void ShowSettings(bool isShow)
    {
        menuAnim.SetBool("isSettings", isShow);
    }

    public void ShowMessageBox(bool isShow)
    {

    }

}
