using System;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationMenu : MonoBehaviour
{
    public InputField username;// ��� ������������
    public InputField password;// ������

    public StartMenu startMenu;// ��������� ����

    /// <summary>
    /// ������ �����������
    /// </summary>
    /// <returns>������ ������������� ������������</returns>
    public void LogIn()
    {
        if (username.text != "" && password.text != "")
        {
            if (username.text == GameManager.localUsername && password.text == GameManager.localPassword)
            {
                GameManager.isLocalAccount = true;
                ResetInputFields();
                startMenu.ShowMenu();
            }
            else
            {
                GameManager.username = username.text;
                string message = Client.SendingMessage(GameManager.clientId, String.Format("LogIn_{0}_{1}", username.text, password.text));
                ResetInputFields();
                if (message == "user found")
                {
                    startMenu.ShowMenu();
                }
                else
                {
                    startMenu.ShowMessageBox("This user does not exist.");
                }
            }

        }
        else
        {
            startMenu.ShowMessageBox("This user does not exist."); ;
        }
    }

    /// <summary>
    /// ������ �����������
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
    /// �������� ������� ����
    /// </summary>
    private void ResetInputFields()
    {
        username.text = "";
        password.text = "";
    }
}
