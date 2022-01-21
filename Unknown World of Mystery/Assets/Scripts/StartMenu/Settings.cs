using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Dropdown screenResolution;
    public Slider volumeSounds;
    public Dropdown screenMode;
    public Slider volumeMusic;

    public StartMenu startMenu;

    public void GetSettings()
    {
        screenResolution.value = GameManager.screenResolution;
        volumeSounds.value = GameManager.volumeSounds;
        screenMode.value = GameManager.screenMode;
        volumeMusic.value = GameManager.volumeMusic;
    }

    public void Apply()
    {
        startMenu.HideStartMenuItems("isSettings");
    }
}
