using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour
{
    public Dropdown screenResolution;// разрешение экрана
    public Slider volumeSounds;// громкость звуков
    public Dropdown screenMode;// вид экрана
    public Slider volumeMusic;// громкость музыки

    public StartMenu startMenu;// начальное меню

    /// <summary>
    /// получить настройки и обновить глобальные переменные
    /// </summary>
    /// <param name="pathToSettings">путь к файлу настроек</param>
    /// <returns>настройки</returns>
    public static string[] GetSettings(string pathToSettings)
    {
        string[] setting = FileManager.ReadingFile(pathToSettings).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        IEnumerator settings = setting.GetEnumerator();
        int counter = 0;
        while (settings.MoveNext())
        {
            setting[counter] = settings.Current.ToString().Substring(settings.Current.ToString().IndexOf(':') + 1);
            counter++;
        }

        ScreenManager.screenResolution = int.Parse(setting[0]);
        AudioManager.volumeSounds = float.Parse(setting[1]);
        ScreenManager.screenMode = int.Parse(setting[2]);
        AudioManager.volumeMusic = float.Parse(setting[3]);

        return setting;
    }

    /// <summary>
    /// установить настройки в файле
    /// </summary>
    /// <param name="pathToSettings">путь к файлу настроек</param>
    public void SetSettings(string pathToSettings)
    {
        string settings = String.Format("screenResolution:{0}\nvolumeSounds:{1}\nscreenMode:{2}\nvolumeMusic:{3}", screenResolution.value, volumeSounds.value, screenMode.value, volumeMusic.value);
        FileManager.WritingFile(pathToSettings, settings);
    }

    /// <summary>
    /// обновить настройки в игре
    /// </summary>
    /// <param name="setting">настройки</param>
    public void UpdateSettings(string[] setting)
    {
        screenResolution.value = int.Parse(setting[0]);
        volumeSounds.value = float.Parse(setting[1]);
        screenMode.value = int.Parse(setting[2]);
        volumeMusic.value = float.Parse(setting[3]);
    }

    /// <summary>
    /// кнопка применить настройки
    /// </summary>
    public void Apply()
    {
        SetSettings(FileManager.pathToSettings);
        GetSettings(FileManager.pathToSettings);
        ScreenManager.SetScreen();
        startMenu.music.volume = AudioManager.volumeMusic;
        startMenu.HideStartMenuItems("isSettings");
    }
}
