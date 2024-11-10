using UnityEngine;

public class PlayersController : MonoBehaviour
{
    public bool moveInventoried = false;

    public bool canMove = true;

    // Переменные для скорости движения и силы прыжка
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    // Переменная для хранения ссылки на компонент Rigidbody
    private Rigidbody rb;

    // Переменные для управления движением по осям X и Z
    private float moveX;
    private float moveZ;

    // Переменная для проверки, находится ли персонаж на земле
    private bool isGrounded;

    public float distanceRayDown = 1.5f;

    public Animator _anim;

    // Метод вызывается при запуске игры
    void Start()
    {
        // Получаем компонент Rigidbody, прикрепленный к этому объекту
        rb = GetComponent<Rigidbody>();

        _anim.SetBool("Idle", true);
    }

    // Метод вызывается каждый кадр
    void Update()
    {
        if (canMove)
        {
            if (!GameObject.FindGameObjectWithTag("ScriptObj").GetComponent<Ui_Script>()._isMobileInput)
            {
                if (Input.GetAxis("Horizontal") != 0)
                    _anim.SetBool("Idle", false);
                else
                    _anim.SetBool("Idle", true);
                // Получаем входные данные по осям движения (WASD или стрелки)
                if (!moveInventoried)
                    moveX = Input.GetAxis("Horizontal");
                else
                    moveX = -Input.GetAxis("Horizontal");
            }
            // Отключили отслеживание изменения позиции потому что игра предназначена для передвижения по одной оси
            //moveZ = Input.GetAxis("Vertical");

            // Проверяем, нажата ли клавиша пробела и находится ли персонаж на земле
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded)
            {
                // Применяем силу вверх для выполнения прыжка
                rb.velocity = new Vector3(0, jumpForce, 0);
            }
        }
        else
            _anim.SetBool("Idle", true);
    }

    // Метод вызывается с фиксированным интервалом времени (для работы с физикой)
    void FixedUpdate()
    {
        if (canMove)
        {
            // Рассчитываем движение по осям X и Z
            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            // Применяем движение к Rigidbody, сохраняя текущую вертикальную скорость
            rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);

            Ray ray1 = new Ray(transform.position, -transform.up);
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1f, Color.green);

            if (Physics.SphereCast(ray1, distanceRayDown, out hit, distanceRayDown))
                isGrounded = true;
            else
                isGrounded = false;
        }
        else
            rb.velocity = Vector3.zero;
    }

    public void MoveLeftDown()
    {
        if (canMove)
        {
            _anim.SetBool("Idle", false);
            if (!moveInventoried)
                moveX = -1;
            else
                moveX = 1;
        }
    }
    public void MoveRightDown()
    {
        if (canMove)
        {
            _anim.SetBool("Idle", false);
            if (!moveInventoried)
                moveX = 1;
            else
                moveX = -1;
        }
    }

    public void MoveUp()
    {
        _anim.SetBool("Idle", true);
        moveX = 0;
    }

    public void JumpDown()
    {
        if (canMove && isGrounded)
            rb.velocity = new Vector3(0, jumpForce, 0);
    }

    public void JumpUp()
    {
        if (canMove && isGrounded)
            rb.velocity = new Vector3(0, 0, 0);
    }

    /*
    // Метод вызывается при соприкосновении с другим объектом
    private void OnCollisionEnter(Collision collision)
    {
        // Если персонаж касается объекта с тегом "Ground", то он на земле
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Метод вызывается при прекращении соприкосновения с другим объектом
    private void OnCollisionExit(Collision collision)
    {
        // Если персонаж перестал касаться объекта с тегом "Ground", то он не на земле
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    */
}
