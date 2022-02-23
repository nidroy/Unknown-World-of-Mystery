using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static string username;

    public static bool isLocalAccount;
    public static string localUsername = "username";
    public static string localPassword = "password";

    public static string pathToSettings = "C:\\Settings\\settings.txt";

    public static string characterName;
    public static int characterLevel;
    public static string timeInTheGame;
    public static int location;
}
