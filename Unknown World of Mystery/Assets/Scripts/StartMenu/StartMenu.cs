using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartMenu : MonoBehaviour
{
    public AuthorizationMenu authorizationMenu;
    public Settings settings;

    public Animator menuAnim;

    public GameObject messageBox;
    public Text message;

    public void ShowMenu()
    {
        string[] serverResponse = authorizationMenu.LogIn().Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        if (serverResponse[0] == "user found")
        {
            string[] settings = serverResponse[1].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            GameManager.screenResolution = int.Parse(settings[0]);
            GameManager.volumeSounds = float.Parse(settings[1]);
            GameManager.screenMode = int.Parse(settings[2]);
            GameManager.volumeMusic = float.Parse(settings[3]);
            menuAnim.SetBool("isMenu", true);
        }
        else
        {
            ShowMessageBox("this user does not exist");
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

    public void ShowSettings()
    {
        settings.GetSettings();
        menuAnim.SetBool("isSettings", true);
    }

    public void ShowMessageBox(string text)
    {
        messageBox.SetActive(true);
        message.text = text;
    }

    public void HideMessageBox()
    {
        messageBox.SetActive(false);
    }

    public void HideStartMenuItems(string item)
    {
        menuAnim.SetBool(item, false);
    }

}
