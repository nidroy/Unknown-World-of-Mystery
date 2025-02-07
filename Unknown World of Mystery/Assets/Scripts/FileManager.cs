using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    public static string pathToSettings = Application.dataPath + "/Settings/settings.txt"; // ���� � ����� � �����������
    public static string pathToLocalizationRU = Application.dataPath + "/Localization/RU.txt"; // ���� � ����� � ������� ������������
    public static string pathToLocalizationEN = Application.dataPath + "/Localization/EN.txt"; // ���� � ����� � ���������� ������������
    public static string serverPath = Application.dataPath + "/Server/Unknown World of Mystery server.exe"; // ���� � ������� 
    public static string serverChatPath = Application.dataPath + "/ChatServer/Unknown World of Mystery chat server.exe"; // ���� � ������� ����
    public static string pathToKey = Application.dataPath + "/Key/key.txt"; // ���� � ����� � ������ 
    //public static string pathToKey = "P:\\Projects\\UnityProjects\\Unknown World of Mystery\\Unknown-World-of-Mystery-repository\\Unknown World of Mystery server\\bin\\Debug\\Unknown World of Mystery_Data\\Key\\key.txt"; // ���� � ����� � ������ 
    //public static string pathToKey = "C:\\Users\\nidro\\Projects\\UnityProjects\\Unknown World of Mystery\\Unknown-World-of-Mystery-repository\\Unknown World of Mystery server\\bin\\Debug\\Unknown World of Mystery_Data\\Key\\key.txt"; // ����

    /// <summary>
    /// ������ �����
    /// </summary>
    /// <param name="filePath">���� � �����</param>
    /// <returns>���������� �����</returns>
    public static string ReadingFile(string filePath)
    {
        StreamReader sr = new StreamReader(filePath);

        string result = "";

        while (sr.EndOfStream != true)
        {
            result += sr.ReadLine() + "\n";
        }

        sr.Close();

        return result.Remove(result.Length - 1);
    }

    /// <summary>
    /// ������ � ����
    /// </summary>
    /// <param name="filePath">���� � �����</param>
    /// <param name="text">������ ��� ������ � ����</param>
    public static void WritingFile(string filePath, string text)
    {
        FileStream file = new FileStream(filePath, FileMode.Create);
        StreamWriter writer = new StreamWriter(file);
        writer.Write(text);
        writer.Close();
    }
}
