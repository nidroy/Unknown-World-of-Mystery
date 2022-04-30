using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    public static string pathToSettings = Application.dataPath + "/Settings/settings.txt"; // путь к файлу с настройками
    public static string serverPath = Application.dataPath + "/Server/Unknown World of Mystery server.exe"; // путь к серверу 
    //public static string pathToKey = Application.dataPath + "/Key/key.txt"; // путь к файлу с ключем 
    //public static string pathToKey = "P:\\Projects\\UnityProjects\\Unknown World of Mystery\\Unknown-World-of-Mystery-repository\\Unknown World of Mystery server\\bin\\Debug\\Unknown World of Mystery_Data\\Key\\key.txt"; // путь к файлу с ключем 
    public static string pathToKey = "C:\\Users\\nidro\\Projects\\UnityProjects\\Unknown World of Mystery\\Unknown-World-of-Mystery-repository\\Unknown World of Mystery server\\bin\\Debug\\Unknown World of Mystery_Data\\Key\\key.txt"; // ноут

    /// <summary>
    /// чтение файла
    /// </summary>
    /// <param name="filePath">путь к файлу</param>
    /// <returns>содержимое файла</returns>
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
    /// запись в файл
    /// </summary>
    /// <param name="filePath">путь к файлу</param>
    /// <param name="text">данные для записи в файл</param>
    public static void WritingFile(string filePath, string text)
    {
        FileStream file = new FileStream(filePath, FileMode.Create);
        StreamWriter writer = new StreamWriter(file);
        writer.Write(text);
        writer.Close();
    }
}
