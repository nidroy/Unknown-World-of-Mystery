using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DaysOfWeek : MonoBehaviour
{
    public Tree tree; // дерево
    public ThirdLocation thirdLocation; // третья локация

    public AudioSource portalSound; // звук спуска портала

    public Animator portalAnim; // анимации портала

    public Sprite selectedDayIcon; // иконка выбранного дня
    public Sprite notSelectedDayIcon; // иконка не выбранного дня

    public Image[] icon; // иконки на кнопках
    public Button[] button; // кнопки
    public EventTrigger[] trigger; // тригеры на кнопках

    private int[] arrayDays = new int[] { 0, 0, 0, 0, 0, 0, 0 }; // массив дней
    private int counter = 1; // счетчик
    
    /// <summary>
    /// выбрать день
    /// </summary>
    /// <param name="numberDay">номер дня</param>
    public void ChooseDay(int numberDay)
    {
        icon[numberDay].sprite = selectedDayIcon;
        button[numberDay].enabled = false;
        trigger[numberDay].enabled = false;
        arrayDays[numberDay] = counter;
        counter++;
    }

    /// <summary>
    /// обновить поле
    /// </summary>
    public void UpdatingField()
    {
        counter = 1;
        for (int i = 0; i < 7; i++)
        {
            icon[i].sprite = notSelectedDayIcon;
            button[i].enabled = true;
            trigger[i].enabled = true;
            arrayDays[i] = 0;
        }
    }

    /// <summary>
    /// закончить игру
    /// </summary>
    public void FinishGame()
    {
        if(RiddleIsSolved())
        {
            tree.button.SetActive(false);
            tree.riddleIsSolved.SetActive(true);
            thirdLocation.audioManager.PlaySounds(portalSound);
            portalAnim.SetBool("isLower", true);
        }
    }

    /// <summary>
    /// загадка разгадана?
    /// </summary>
    /// <returns>да или нет</returns>
    private bool RiddleIsSolved()
    {
        for(int i = 0; i < 7; i++)
        {
            if(arrayDays[i] != i+1)
            {
                return false;
            }
        }
        return true;
    }

}
