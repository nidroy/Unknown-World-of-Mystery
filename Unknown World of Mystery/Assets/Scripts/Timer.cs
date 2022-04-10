using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text clock; // ���� ������ �������

    private float seconds; // �������
    private int minutes; // ������
    private int hours; // ����

    private bool isPause; // �����

    /// <summary>
    /// ������������� ����������
    /// </summary>
    private void Start()
    {
        isPause = false;   
    }

    /// <summary>
    /// ������ �������
    /// </summary>
    private void Update()
    {
        if(!isPause)
        {
            TimeCounting();
            TimeDisplay();
        }
    }

    /// <summary>
    /// ������ �������
    /// </summary>
    private void TimeCounting()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }
        if (minutes == 60)
        {
            hours++;
            minutes = 0;
        }
    }

    /// <summary>
    /// ����� ������� �� �����
    /// </summary>
    private void TimeDisplay()
    {
        clock.text = String.Format("{0}:{1}:{2}", hours, minutes, (int)seconds);
    }

    /// <summary>
    /// ������ �������
    /// </summary>
    public void StartTimer()
    {
        string[] time = GameManager.timeInTheGame.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        hours = int.Parse(time[0]);
        minutes = int.Parse(time[1]);
        seconds = float.Parse(time[2]);
        isPause = false;
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    public void StopTimer()
    {
        isPause = true;
        GameManager.timeInTheGame = clock.text;
    }
}
