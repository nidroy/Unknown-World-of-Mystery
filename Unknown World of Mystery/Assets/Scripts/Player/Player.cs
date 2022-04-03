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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            characterAnim.SetBool("isEndTeleportation", false);
            isFloor = true;
        }
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FirstLocation.isOpenDoor = true;
            SecondLocation.isOpenDoor = true;
            isMove = false;
        }
    }
   
}
