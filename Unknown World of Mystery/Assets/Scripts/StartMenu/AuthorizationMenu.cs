using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationMenu : MonoBehaviour
{
    public InputField username;
    public InputField password;

    public StartMenu startMenu;

    public string LogIn()
    {
        GameManager.username = username.text;
        return Client.SendingMessage(GameManager.username, String.Format("LogIn_{0}_{1}", username.text, password.text));
    }

    public void Register()
    {
        if(username.text != "" && password.text != "")
        {
            startMenu.ShowMessageBox("The user is registered. Log in.");
            Debug.Log(Client.SendingMessage(GameManager.username, String.Format("Register_{0}_{1}", username.text, password.text)));
        }
        else
        {
            startMenu.ShowMessageBox("Login or password not entered.");
        }      
    }
}
