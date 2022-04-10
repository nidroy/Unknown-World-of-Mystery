using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DaysOfWeek : MonoBehaviour
{
    public Tree tree; // ������
    public ThirdLocation thirdLocation; // ������ �������

    public AudioSource portalSound; // ���� ������ �������

    public Animator portalAnim; // �������� �������

    public Sprite selectedDayIcon; // ������ ���������� ���
    public Sprite notSelectedDayIcon; // ������ �� ���������� ���

    public Image[] icon; // ������ �� �������
    public Button[] button; // ������
    public EventTrigger[] trigger; // ������� �� �������

    private int[] arrayDays = new int[] { 0, 0, 0, 0, 0, 0, 0 }; // ������ ����
    private int counter = 1; // �������
    
    /// <summary>
    /// ������� ����
    /// </summary>
    /// <param name="numberDay">����� ���</param>
    public void ChooseDay(int numberDay)
    {
        icon[numberDay].sprite = selectedDayIcon;
        button[numberDay].enabled = false;
        trigger[numberDay].enabled = false;
        arrayDays[numberDay] = counter;
        counter++;
    }

    /// <summary>
    /// �������� ����
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
    /// ��������� ����
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
    /// ������� ���������?
    /// </summary>
    /// <returns>�� ��� ���</returns>
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
