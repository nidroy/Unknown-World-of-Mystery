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
        if (username.text != "" && password.text != "")
        {
            if(username.text == GameManager.localUsername && password.text == GameManager.localPassword)
            {
                GameManager.isLocalAccount = true;
                username.text = "";
                password.text = "";
                return "user found";
            }
            GameManager.username = username.text;
            string message = Client.SendingMessage(GameManager.username, String.Format("LogIn_{0}_{1}", username.text, password.text));
            username.text = "";
            password.text = "";
            return message;

        }
        else
        {
            return "user not found";
        }
    }

    public void Register()
    {
        if(username.text != "" && password.text != "")
        {
            if (username.text == GameManager.localUsername && password.text == GameManager.localPassword)
            {
                startMenu.ShowMessageBox("This is a local account.");
            }
            else
            {
                startMenu.ShowMessageBox("The user is registered. Log in.");
                Debug.Log(Client.SendingMessage(GameManager.username, String.Format("Register_{0}_{1}", username.text, password.text)));
                username.text = "";
                password.text = "";
            }
        }
        else
        {
            startMenu.ShowMessageBox("Login or password not entered.");
        }      
    }
}
