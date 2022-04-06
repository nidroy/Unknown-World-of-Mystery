using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Character
{
    public GameObject dialogButton; // кнопка начала диалога

    /// <summary>
    /// открыть телепорт
    /// </summary>
    public void OpenTeleport()
    {
        characterAnim.SetBool("isOpenTeleport", true);
    }

    /// <summary>
    /// коснуться пола
    /// </summary>
    public override void EnterFloor()
    {
        isFloor = true;
    }

    /// <summary>
    /// коснуться тригера
    /// </summary>
    public override void EnterTrigger()
    {
        isMove = false;
        dialogButton.SetActive(true);
    }
}
