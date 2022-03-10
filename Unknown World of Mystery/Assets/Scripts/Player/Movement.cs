using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator playerAnim;
    public AudioSource steps;
    public float speed;

    private Vector2 moveVector;
    private int direction;
    private bool isFloor;

    public static bool isMove;

    public void ChangeDirection(int newDirection)
    {
        direction = newDirection;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 0;
        isMove = false;
        isFloor = false;
    }

    void Update()
    {
        if (isMove)
            Move(direction);
        else
        {
            playerAnim.SetBool("isRun", false);
            steps.mute = true;
        }
    }

    private void Move(int direction)
    {
        moveVector.x = direction;
        if(direction == 0)
            moveVector.x = Input.GetAxis("Horizontal");
        if (moveVector.x == 0)
        {
            playerAnim.SetBool("isRun", false);
            steps.mute = true;
        }
        else if (moveVector.x < 0)
        {
            Flip(180);
            if (isFloor)
            {
                playerAnim.SetBool("isRun", true);
                steps.mute = false;
            }
        }
        else if (moveVector.x > 0)
        {
            Flip(0);
            if (isFloor)
            {
                playerAnim.SetBool("isRun", true);
                steps.mute = false;
            }
        }
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    private void Flip(int rotation)
    {
        rb.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloor = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isFloor = false;
            steps.mute = true;
            playerAnim.SetBool("isRun", false);
        }
    }
}
