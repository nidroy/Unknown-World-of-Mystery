using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string username; // ��� ������������

    public static bool isLocalAccount; // ���� � ��������� �������
    public static string localUsername = "username"; // ��� ������������ ��� ����� � ��������� �������
    public static string localPassword = "password"; // ������ ��� ����� � ��������� �������

    public static string characterName; // ��� ���������
    public static int characterLevel; // ������� ���������
    public static string timeInTheGame = "0:0:0"; // ����� � ����
}
