using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private GameObject footstepsSFX;
    private Rigidbody2D rb;
    private float jumpForce;
    private float gravityForce;
    private float distanceToGround;
    [SerializeField] bool isGrounded;

    void Start()
    {
        footstepsSFX = GameObject.Find("FootstepsSFX");
        rb = GetComponent<Rigidbody2D>();
        jumpForce = PlayerProperties.jumpForce;
        gravityForce = PlayerProperties.gravityForce;
        distanceToGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
    }

    void Update()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            if (!PlayerCollector.isSpeedModified)
                PlayerProperties.speedForce = 110f;

            if ((Input.GetAxis("RTJump") > 0 || Input.GetKey(KeyCode.Space)) && IsGrounded())
            {
                PlayerProperties.isStickActive = false;

                if (!PlayerCollector.isSpeedModified)
                    PlayerProperties.speedForce = 110f;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            footstepsSFX.GetComponent<AudioSource>().Stop();
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.y) > 0.001f && !PlayerProperties.isStickActive)
        {
            rb.velocity += gravityForce * Time.deltaTime * Vector2.down;
        }
    }

    private bool IsGrounded()
    {
        if (!isGrounded && Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + 0.1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ceiling"))
            isGrounded = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ceiling"))
            isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ceiling"))
            isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ceiling"))
            isGrounded = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ceiling"))
            isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ceiling"))
            isGrounded = false;
    }
}
