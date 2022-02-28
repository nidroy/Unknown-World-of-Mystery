using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static int screenResolution;// разрешение экрана
    public static int screenMode;// вид экрана

    /// <summary>
    /// словарь разрешений экрана
    /// </summary>
    public static Dictionary<int, IScreenResolution> dictionaryScreenResolutions = new Dictionary<int, IScreenResolution>();

    /// <summary>
    /// установить настройки экрана
    /// </summary>
    public static void SetScreen()
    {
        if (screenMode == 0)
        {
            SetScreenResolution(true);
        }
        else if (screenMode == 1)
        {
            SetScreenResolution(false);
        }
    }

    /// <summary>
    /// установить разрешение экрана
    /// </summary>
    /// <param name="isFullscreen">полноэкранный вид экрана</param>
    public static void SetScreenResolution(bool isFullscreen)
    {
        FillInTheDictionaryScreenResolutions(isFullscreen);
        dictionaryScreenResolutions[screenResolution].SetScreenResolution();
    }

    /// <summary>
    /// заполнение словаря разрешений экрана
    /// </summary>
    /// <param name="isFullscreen">полноэкранный вид экрана</param>
    public static void FillInTheDictionaryScreenResolutions(bool isFullscreen)
    {
        IScreenResolution setScreenResolutionFullHD = new SetScreenResolutionFullHD(isFullscreen);
        IScreenResolution setScreenResolutionHD = new SetScreenResolutionHD(isFullscreen);
        dictionaryScreenResolutions.Clear();
        dictionaryScreenResolutions.Add(0, setScreenResolutionFullHD);
        dictionaryScreenResolutions.Add(1, setScreenResolutionHD);
    }

    /// <summary>
    /// интерфейс для разрешения экрана
    /// </summary>
    public interface IScreenResolution
    {
        void SetScreenResolution();
    }

    /// <summary>
    /// класс для установки разрешения Full HD
    /// </summary>
    public class SetScreenResolutionFullHD : IScreenResolution
    {
        bool isFullscreen;

        public SetScreenResolutionFullHD(bool isFullscreen)
        {
            this.isFullscreen = isFullscreen;
        }

        public void SetScreenResolution()
        {
            Screen.SetResolution(1920, 1080, isFullscreen);
        }
    }

    /// <summary>
    /// класс для установки разрешения HD
    /// </summary>
    public class SetScreenResolutionHD : IScreenResolution
    {
        bool isFullscreen;

        public SetScreenResolutionHD(bool isFullscreen)
        {
            this.isFullscreen = isFullscreen;
        }

        public void SetScreenResolution()
        {
            Screen.SetResolution(1366, 768, isFullscreen);
        }
    }
}
