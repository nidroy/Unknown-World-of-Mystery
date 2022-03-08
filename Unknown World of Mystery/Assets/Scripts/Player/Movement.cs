using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private Vector2 moveVector;
    private int direction;

    public void ChangeDirection(int newDirection)
    {
        direction = newDirection;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 0;
    }

    void Update()
    {
        Move(direction);
    }

    private void Move(int direction)
    {
        moveVector.x = direction;
        if(direction == 0)
            moveVector.x = Input.GetAxis("Horizontal");
        if(moveVector.x < 0)
        {
            Flip(180);
        }
        else if (moveVector.x > 0)
        {
            Flip(0);
        }
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    private void Flip(int rotation)
    {
        rb.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
