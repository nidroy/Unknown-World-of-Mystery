using System;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationMenu : MonoBehaviour
{
    public InputField username;// имя пользователя
    public InputField password;// пароль

    public StartMenu startMenu;// начальное меню

    /// <summary>
    /// кнопка авторизации
    /// </summary>
    /// <returns>строка существование пользователя</returns>
    public string LogIn()
    {
        if (username.text != "" && password.text != "")
        {
            if(username.text == GameManager.localUsername && password.text == GameManager.localPassword)
            {
                GameManager.isLocalAccount = true;
                ResetInputFields();
                return "user found";
            }
            GameManager.username = username.text;
            string message = Client.SendingMessage(GameManager.clientId, String.Format("LogIn_{0}_{1}", username.text, password.text));
            ResetInputFields();
            return message;

        }
        else
        {
            return "user not found";
        }
    }

    /// <summary>
    /// кнопка регистрации
    /// </summary>
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
                if (Client.SendingMessage(GameManager.clientId, String.Format("Register_{0}_{1}", username.text, password.text)) == "The user exists")
                {
                    startMenu.ShowMessageBox("The user exists.");
                }
                else
                {
                    startMenu.ShowMessageBox("The user is registered. Log in.");
                }
            }
        }
        else
        {
            startMenu.ShowMessageBox("Login or password not entered.");
        }
        ResetInputFields();
    }

    /// <summary>
    /// сборсить входные поля
    /// </summary>
    private void ResetInputFields()
    {
        username.text = "";
        password.text = "";
    }
}
