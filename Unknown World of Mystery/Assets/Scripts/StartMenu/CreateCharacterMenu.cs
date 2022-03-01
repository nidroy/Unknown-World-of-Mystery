using UnityEngine;
using UnityEngine.UI;
using System;


public class CreateCharacterMenu : MonoBehaviour
{
    public InputField characterName;// имя персонажа
    public Dropdown characterLevel;// уровень персонажа

    public StartMenu startMenu;// начальное меню

    /// <summary>
    /// кнопка создания персонажа
    /// </summary>
    public void Create()
    {
        if (GameManager.isLocalAccount)
        {
            startMenu.ShowMessageBox("A local account is used.");
        }
        else
        {
            if (characterName.text != "")
            {
                if (Client.SendingMessage(GameManager.username, String.Format("CreateCharacter_{0}_{1}_{2}", GameManager.username, characterName.text, characterLevel.value)) == "The character exists")
                {
                    startMenu.ShowMessageBox("The character exists.");
                }
                else
                {
                    startMenu.HideStartMenuItems("isCreateCharacter");
                }
                characterName.text = "";
                characterLevel.value = 0;
            }
            else
            {
                startMenu.ShowMessageBox("Enter the name of the character.");
            }
        }
    }
}
