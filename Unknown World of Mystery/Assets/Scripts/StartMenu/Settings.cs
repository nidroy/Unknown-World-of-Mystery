using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Settings : MonoBehaviour
{
    public Dropdown screenResolution;
    public Slider volumeSounds;
    public Dropdown screenMode;
    public Slider volumeMusic;

    public StartMenu startMenu;

    public void GetSettings(string pathToSettings)
    {
        string[] setting = ReadingFile(pathToSettings).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        IEnumerator settings = setting.GetEnumerator();
        int counter = 0;
        while (settings.MoveNext())
        {
            setting[counter] = settings.Current.ToString().Substring(settings.Current.ToString().IndexOf(':') + 1);
            counter++;
        }
        screenResolution.value = int.Parse(setting[0]);
        volumeSounds.value = float.Parse(setting[1]);
        screenMode.value = int.Parse(setting[2]);
        volumeMusic.value = float.Parse(setting[3]);
    }

    public void SetSettings(string pathToSettings)
    {
        string settings = String.Format("screenResolution:{0}\nvolumeSounds:{1}\nscreenMode:{2}\nvolumeMusic:{3}", screenResolution.value, volumeSounds.value, screenMode.value, volumeMusic.value);
        WritingFile(pathToSettings, settings);
    }

    public void Apply()
    {
        SetSettings(GameManager.pathToSettings);
        startMenu.HideStartMenuItems("isSettings");
    }

    public string ReadingFile(string filePath)
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

    public void WritingFile(string filePath, string text)
    {
        FileStream file = new FileStream(filePath, FileMode.Create);
        StreamWriter writer = new StreamWriter(file);
        writer.Write(text); 
        writer.Close();
    }
}
