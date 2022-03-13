using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator characterAnim;
    public AudioSource steps;
    public float speed;

    private Vector2 moveVector;
    private int direction;

    public bool isMove { get; set; }
    public bool isFloor { get; set; }

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
            characterAnim.SetBool("isRun", false);
            steps.mute = true;
        }
    }

    private void Move(int direction)
    {
        moveVector.x = direction;
        if (moveVector.x == 0)
        {
            characterAnim.SetBool("isRun", false);
            steps.mute = true;
        }
        else if (moveVector.x < 0)
        {
            Flip(180);
            if (isFloor)
            {
                characterAnim.SetBool("isRun", true);
                steps.mute = false;
            }
        }
        else if (moveVector.x > 0)
        {
            Flip(0);
            if (isFloor)
            {
                characterAnim.SetBool("isRun", true);
                steps.mute = false;
            }
        }
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    private void Flip(int rotation)
    {
        rb.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
