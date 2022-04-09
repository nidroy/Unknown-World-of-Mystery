using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Rigidbody2D rb; // физика персонажа
    public Animator characterAnim; // анимации персонажа
    public AudioSource steps; // звуки шагов
    public float speed; // скорость

    private Vector2 moveVector; // вектор перемещения

    public int direction { get; set; } // направление движения
    public bool isMove { get; set; } // будет ли движение?
    public bool isFloor { get; set; } // персонаж на полу?

    /// <summary>
    /// инициализация переменных
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 0;
        isMove = false;
        isFloor = false;
    }

    /// <summary>
    /// движение персонажа
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
    /// функция перемещения
    /// </summary>
    /// <param name="direction">направление перемещения</param>
    private void Move(int direction)
    {
        ChooseMovementDependingOnDirection(direction);
        moveVector.x = direction;
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    /// <summary>
    /// функция выбора типа перемещения в зависимости от направления
    /// </summary>
    /// <param name="direction">направление перемещения</param>
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
    /// остановить перемещение
    /// </summary>
    private void StopMovement()
    {
        characterAnim.SetBool("isRun", false);
        steps.mute = true;
    }

    /// <summary>
    /// перемещение влево
    /// </summary>
    private void MovementToLeft()
    {
        Flip(180);
        MovementAnimation(isFloor);
    }

    /// <summary>
    /// перемещение вправо
    /// </summary>
    private void MovementToRight()
    {
        Flip(0);
        MovementAnimation(isFloor);
    }

    /// <summary>
    /// включение анимации перемещения
    /// </summary>
    /// <param name="isFloor">проверка на нахождение персонажа на поверхности</param>
    private void MovementAnimation(bool isFloor)
    {
        if (isFloor)
        {
            characterAnim.SetBool("isRun", true);
            steps.mute = false;
        }
    }

    /// <summary>
    /// поворот
    /// </summary>
    /// <param name="rotation">градус поворота</param>
    private void Flip(int rotation)
    {
        rb.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    /// <summary>
    /// коснуться объекта
    /// </summary>
    /// <param name="collision">объект касания</param>
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
    /// нахождение персонажа вне пола
    /// </summary>
    /// <param name="collision">объект касания</param>
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
    /// объявление метода касания пола
    /// </summary>
    public abstract void EnterFloor();

    /// <summary>
    /// объявление метода касания тригера
    /// </summary>
    public abstract void EnterTrigger();
}
