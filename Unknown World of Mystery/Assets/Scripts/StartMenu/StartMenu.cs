using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AuthorizationMenu authorizationMenu;
    public Settings settings;
    public ChooseCharacterMenu chooseCharacterMenu;

    public Animator menuAnim;
    public Animator gatesAnim;

    public GameObject messageBox;
    public Text message;

    public GameObject loadObject;

    public void ShowMenu()
    {
        string[] serverResponse = authorizationMenu.LogIn().Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        if (serverResponse[0] == "user found")
        {
            serverResponse = serverResponse[1].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            settings.SetSettings(int.Parse(serverResponse[0]), float.Parse(serverResponse[1]), int.Parse(serverResponse[2]), float.Parse(serverResponse[3]));
            menuAnim.SetBool("isMenu", true);
        }
        else
        {
            ShowMessageBox("this user does not exist");
        }
    }

    public void ShowChooseCharacter()
    {
        menuAnim.SetBool("isChooseCharacter", true);
        chooseCharacterMenu.isUpdateItems = true;
    }

    public void ShowCreateCharacter()
    {
        menuAnim.SetBool("isCreateCharacter", true);
    }

    public void ShowSettings()
    {
        settings.GetSettings(GameManager.screenResolution, GameManager.volumeSounds, GameManager.screenMode, GameManager.volumeMusic);
        Debug.Log(settings.ReadingFile(GameManager.filePath));
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

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        gatesAnim.SetBool("isClose", true);
    }

    private void Update()
    {
        if(loadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(GameManager.location + 1);
        }
    }
}
