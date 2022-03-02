using System;
using System.IO;

namespace Unknown_World_of_Mystery_server
{
    public class FileManager
    {
        public static string pathToKey = Environment.CurrentDirectory + "\\Unknown World of Mystery_Data\\Key\\key.txt"; // путь к файлу с ключем 
        public static string pathToDatabase = Environment.CurrentDirectory + "\\Database\\Unknown World of Mystery database.mdf"; // путь к бд 

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
}
