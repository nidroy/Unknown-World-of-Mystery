using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static int screenResolution;
    public static int screenMode;

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

    public static void SetScreenResolution(bool isFullscreen)
    {
        if (screenResolution == 0)
        {
            Screen.SetResolution(1920, 1080, isFullscreen);
        }
        else if (screenResolution == 1)
        {
            Screen.SetResolution(1366, 768, isFullscreen);
        }
    }
}
