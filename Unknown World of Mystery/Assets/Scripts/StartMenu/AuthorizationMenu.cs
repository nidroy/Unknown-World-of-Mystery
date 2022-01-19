using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationMenu : MonoBehaviour
{
    public InputField username;
    public InputField password;

    public GameObject messageBox;
    public Text message;

    public string LogIn()
    {
        GameManager.username = username.text;
        return Client.SendingMessage(GameManager.username, String.Format("LogIn_{0}_{1}", username.text, password.text));
    }

    public void Register()
    {
        if(username.text != "" && password.text != "")
        {
            messageBox.SetActive(true);
            message.text = "The user is registered. Log in.";
            Debug.Log(Client.SendingMessage(GameManager.username, String.Format("Register_{0}_{1}", username.text, password.text)));
        }
        else
        {
            messageBox.SetActive(true);
            message.text = "Login or password not entered.";
        }      
    }
}
