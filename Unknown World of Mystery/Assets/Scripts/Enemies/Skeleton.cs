using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Character
{
    public GameObject dialogButton; // ������ ������ �������

    /// <summary>
    /// ������� ��������
    /// </summary>
    public void OpenTeleport()
    {
        characterAnim.SetBool("isOpenTeleport", true);
    }

    /// <summary>
    /// ��������� ����
    /// </summary>
    public override void EnterFloor()
    {
        isFloor = true;
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    public override void EnterTrigger()
    {
        isMove = false;
        dialogButton.SetActive(true);
    }
}
