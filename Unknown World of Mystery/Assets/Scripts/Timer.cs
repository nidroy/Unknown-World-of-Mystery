using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text clock; // поле вывода времени

    private float seconds; // секунды
    private int minutes; // минуты
    private int hours; // часы

    private bool isPause; // пауза

    /// <summary>
    /// инициализация переменных
    /// </summary>
    private void Start()
    {
        isPause = false;   
    }

    /// <summary>
    /// работа таймера
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
    /// отсчет времени
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
    /// вывод времени на экран
    /// </summary>
    private void TimeDisplay()
    {
        clock.text = String.Format("{0}:{1}:{2}", hours, minutes, (int)seconds);
    }

    /// <summary>
    /// запуск таймера
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
    /// остановка таймера
    /// </summary>
    public void StopTimer()
    {
        isPause = true;
        GameManager.timeInTheGame = clock.text;
    }
}
