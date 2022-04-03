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

    public int direction { get; set; }
    public bool isMove { get; set; }
    public bool isFloor { get; set; }

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
            StopMovement();
        }
    }

    private void Move(int direction)
    {
        ChooseDirectionOfMovement(direction);
        moveVector.x = direction;
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    private void ChooseDirectionOfMovement(int direction)
    {
        if (direction == 0)
        {
            StopMovement();
        }
        else if (direction < 0)
        {
            MovementToLeft();
        }
        else if (direction > 0)
        {
            MovementToRight();
        }
    }

    private void StopMovement()
    {
        characterAnim.SetBool("isRun", false);
        steps.mute = true;
    }

    private void MovementToLeft()
    {
        Flip(180);
        MovementAnimation(isFloor);
    }

    private void MovementToRight()
    {
        Flip(0);
        MovementAnimation(isFloor);
    }

    private void MovementAnimation(bool isFloor)
    {
        if (isFloor)
        {
            characterAnim.SetBool("isRun", true);
            steps.mute = false;
        }
    }

    private void Flip(int rotation)
    {
        rb.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            characterAnim.SetBool("isRun", false);
            isFloor = false;
            steps.mute = true;
        }
    }
}
