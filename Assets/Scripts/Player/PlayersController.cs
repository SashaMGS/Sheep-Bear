using UnityEngine;

public class PlayersController : MonoBehaviour
{
    public bool moveInventoried = false;

    public bool canMove = true;

    // ���������� ��� �������� �������� � ���� ������
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    // ���������� ��� �������� ������ �� ��������� Rigidbody
    private Rigidbody rb;

    // ���������� ��� ���������� ��������� �� ���� X � Z
    private float moveX;
    private float moveZ;

    // ���������� ��� ��������, ��������� �� �������� �� �����
    private bool isGrounded;

    public float distanceRayDown = 1.5f;

    public Animator _anim;

    // ����� ���������� ��� ������� ����
    void Start()
    {
        // �������� ��������� Rigidbody, ������������� � ����� �������
        rb = GetComponent<Rigidbody>();

        _anim.SetBool("Idle", true);
    }

    // ����� ���������� ������ ����
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
                // �������� ������� ������ �� ���� �������� (WASD ��� �������)
                if (!moveInventoried)
                    moveX = Input.GetAxis("Horizontal");
                else
                    moveX = -Input.GetAxis("Horizontal");
            }
            // ��������� ������������ ��������� ������� ������ ��� ���� ������������� ��� ������������ �� ����� ���
            //moveZ = Input.GetAxis("Vertical");

            // ���������, ������ �� ������� ������� � ��������� �� �������� �� �����
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded)
            {
                // ��������� ���� ����� ��� ���������� ������
                rb.velocity = new Vector3(0, jumpForce, 0);
            }
        }
        else
            _anim.SetBool("Idle", true);
    }

    // ����� ���������� � ������������� ���������� ������� (��� ������ � �������)
    void FixedUpdate()
    {
        if (canMove)
        {
            // ������������ �������� �� ���� X � Z
            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            // ��������� �������� � Rigidbody, �������� ������� ������������ ��������
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
    // ����� ���������� ��� ��������������� � ������ ��������
    private void OnCollisionEnter(Collision collision)
    {
        // ���� �������� �������� ������� � ����� "Ground", �� �� �� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // ����� ���������� ��� ����������� ��������������� � ������ ��������
    private void OnCollisionExit(Collision collision)
    {
        // ���� �������� �������� �������� ������� � ����� "Ground", �� �� �� �� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    */
}
