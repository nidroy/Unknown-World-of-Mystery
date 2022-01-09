using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public Animator menuAnim;

    public void ShowMenu(bool isShow)
    {
        menuAnim.SetBool("isMenu", isShow);
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
}
