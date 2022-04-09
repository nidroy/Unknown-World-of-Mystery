using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Rigidbody2D rb; // ������ ���������
    public Animator characterAnim; // �������� ���������
    public AudioSource steps; // ����� �����
    public float speed; // ��������

    private Vector2 moveVector; // ������ �����������

    public int direction { get; set; } // ����������� ��������
    public bool isMove { get; set; } // ����� �� ��������?
    public bool isFloor { get; set; } // �������� �� ����?

    /// <summary>
    /// ������������� ����������
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 0;
        isMove = false;
        isFloor = false;
    }

    /// <summary>
    /// �������� ���������
    /// </summary>
    private void Update()
    {
        if (isMove)
            Move(direction);
        else
        {
            StopMovement();
        }
    }

    /// <summary>
    /// ������� �����������
    /// </summary>
    /// <param name="direction">����������� �����������</param>
    private void Move(int direction)
    {
        ChooseMovementDependingOnDirection(direction);
        moveVector.x = direction;
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    /// <summary>
    /// ������� ������ ���� ����������� � ����������� �� �����������
    /// </summary>
    /// <param name="direction">����������� �����������</param>
    private void ChooseMovementDependingOnDirection(int direction)
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

    /// <summary>
    /// ���������� �����������
    /// </summary>
    private void StopMovement()
    {
        characterAnim.SetBool("isRun", false);
        steps.mute = true;
    }

    /// <summary>
    /// ����������� �����
    /// </summary>
    private void MovementToLeft()
    {
        Flip(180);
        MovementAnimation(isFloor);
    }

    /// <summary>
    /// ����������� ������
    /// </summary>
    private void MovementToRight()
    {
        Flip(0);
        MovementAnimation(isFloor);
    }

    /// <summary>
    /// ��������� �������� �����������
    /// </summary>
    /// <param name="isFloor">�������� �� ���������� ��������� �� �����������</param>
    private void MovementAnimation(bool isFloor)
    {
        if (isFloor)
        {
            characterAnim.SetBool("isRun", true);
            steps.mute = false;
        }
    }

    /// <summary>
    /// �������
    /// </summary>
    /// <param name="rotation">������ ��������</param>
    private void Flip(int rotation)
    {
        rb.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    /// <param name="collision">������ �������</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            EnterFloor();
        }
        if (collision.gameObject.CompareTag("Trigger"))
        {
            EnterTrigger();
        }
    }

    /// <summary>
    /// ���������� ��������� ��� ����
    /// </summary>
    /// <param name="collision">������ �������</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            characterAnim.SetBool("isRun", false);
            isFloor = false;
            steps.mute = true;
        }
    }

    /// <summary>
    /// ���������� ������ ������� ����
    /// </summary>
    public abstract void EnterFloor();

    /// <summary>
    /// ���������� ������ ������� �������
    /// </summary>
    public abstract void EnterTrigger();
}
