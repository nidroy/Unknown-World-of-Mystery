using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Animator houseAnim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trigger"))
        {
            houseAnim.SetBool("isOpen", true);
            Movement.isMove = false;
        }
    }
}
