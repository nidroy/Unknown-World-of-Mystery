using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour
{
    public Dropdown screenResolution;
    public Slider volumeSounds;
    public Dropdown screenMode;
    public Slider volumeMusic;

    public StartMenu startMenu;

    public void GetSettings(int SR, float VS, int SM, float VM)
    {
        screenResolution.value = SR;
        volumeSounds.value = VS;
        screenMode.value = SM;
        volumeMusic.value = VM;
    }

    public void SetSettings(int SR, float VS, int SM, float VM)
    {
        GameManager.screenResolution = SR;
        GameManager.volumeSounds = VS;
        GameManager.screenMode = SM;
        GameManager.volumeMusic = VM;
    }

    public void Apply()
    {
        SetSettings(screenResolution.value, volumeSounds.value, screenMode.value, volumeMusic.value);
        Debug.Log(Client.SendingMessage(GameManager.username, String.Format("Apply_{0}_{1}_{2}_{3}_{4}", GameManager.username, screenResolution.value, volumeSounds.value, screenMode.value, volumeMusic.value)));
        startMenu.HideStartMenuItems("isSettings");
    }
}
