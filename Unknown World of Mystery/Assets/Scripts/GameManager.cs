using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string username; // имя пользователя

    public static bool isLocalAccount; // вход в локальный аккаунт
    public static string localUsername = "username"; // имя пользователя для входа в локальный аккаунт
    public static string localPassword = "password"; // пароль для входа в локальный аккаунт

    public static string characterName; // имя персонажа
    public static int characterLevel; // уровень персонажа
    public static string timeInTheGame = "0:0:0"; // время в игре
}
