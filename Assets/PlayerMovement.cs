using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float jumpForce = 12f;
    public float wallJumpForce = 10f;
    public float wallSlideSpeed = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool canWallJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        CheckGround();
        Jump();
        CheckWall();
        WallSlide();
        WallJump();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            canWallJump = false;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // Empêche le double saut
        }
    }

    void CheckWall()
    {
        isTouchingWall = Physics2D.OverlapCircle(transform.position, 0.5f, groundLayer);
    }

    void WallSlide()
    {
        isWallSliding = isTouchingWall && !isGrounded && rb.linearVelocity.y < 0;

        if (isWallSliding)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed);
            canWallJump = true;
        }
    }

    void WallJump()
    {
        if (canWallJump && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpForce, jumpForce);
            canWallJump = false;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }
}