using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public void Teleportation()
    {
        characterAnim.SetBool("isTeleportation", true);
    }

    public void EndTeleportation()
    {
        characterAnim.SetBool("isTeleportation", false);
        characterAnim.SetBool("isEndTeleportation", true);
        isMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloor = true;
            characterAnim.SetBool("isEndTeleportation", false);
        }
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FirstLocation.isOpenDoor = true;
            isMove = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloor = false;
            steps.mute = true;
            characterAnim.SetBool("isRun", false);
        }
    }
}
