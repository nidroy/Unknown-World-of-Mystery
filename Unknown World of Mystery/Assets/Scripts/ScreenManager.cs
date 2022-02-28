using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static int screenResolution;// ���������� ������
    public static int screenMode;// ��� ������

    /// <summary>
    /// ������� ���������� ������
    /// </summary>
    public static Dictionary<int, IScreenResolution> dictionaryScreenResolutions = new Dictionary<int, IScreenResolution>();

    /// <summary>
    /// ���������� ��������� ������
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
    /// ���������� ���������� ������
    /// </summary>
    /// <param name="isFullscreen">������������� ��� ������</param>
    public static void SetScreenResolution(bool isFullscreen)
    {
        FillInTheDictionaryScreenResolutions(isFullscreen);
        dictionaryScreenResolutions[screenResolution].SetScreenResolution();
    }

    /// <summary>
    /// ���������� ������� ���������� ������
    /// </summary>
    /// <param name="isFullscreen">������������� ��� ������</param>
    public static void FillInTheDictionaryScreenResolutions(bool isFullscreen)
    {
        IScreenResolution setScreenResolutionFullHD = new SetScreenResolutionFullHD(isFullscreen);
        IScreenResolution setScreenResolutionHD = new SetScreenResolutionHD(isFullscreen);
        dictionaryScreenResolutions.Clear();
        dictionaryScreenResolutions.Add(0, setScreenResolutionFullHD);
        dictionaryScreenResolutions.Add(1, setScreenResolutionHD);
    }

    /// <summary>
    /// ��������� ��� ���������� ������
    /// </summary>
    public interface IScreenResolution
    {
        void SetScreenResolution();
    }

    /// <summary>
    /// ����� ��� ��������� ���������� Full HD
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
    /// ����� ��� ��������� ���������� HD
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
