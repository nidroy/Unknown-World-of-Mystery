using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private Vector2 moveVector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(1);
    }

    public void Move(int direction)
    {
        //moveVector.x *= direction;
        moveVector.x = Input.GetAxis("Horizontal");
        Debug.Log(moveVector.x);
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
}
