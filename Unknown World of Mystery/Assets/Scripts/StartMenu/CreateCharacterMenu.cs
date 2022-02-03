using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CreateCharacterMenu : MonoBehaviour
{
    public Text characterName;
    public Dropdown characterLevel;

    public StartMenu startMenu;
    public void Create()
    {
        if (characterName.text != "")
        {
            Debug.Log(Client.SendingMessage(GameManager.username, String.Format("CreateCharacter_{0}_{1}_{2}", GameManager.username, characterName.text, characterLevel.value)));
            startMenu.HideStartMenuItems("isCreateCharacter");
            characterName.text = "";
            characterLevel.value = 0;
        }
        else
        {
            startMenu.ShowMessageBox("Enter the name of the character.");
        }
    }
}
