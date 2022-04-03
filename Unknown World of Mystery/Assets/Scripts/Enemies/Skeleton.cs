using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Character
{
    public GameObject dialogButton;

    public void OpenTeleport()
    {
        characterAnim.SetBool("isAttack", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloor = true;
        }
        if (collision.gameObject.CompareTag("Trigger"))
        {
            isMove = false;
            dialogButton.SetActive(true);
        }
    }
}
