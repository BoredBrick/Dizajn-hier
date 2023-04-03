using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour 
{
    Rigidbody2D rb;
    float jumpForce;
    float gravityForce;
    float distanceToGround;
    [SerializeField] bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = PlayerProperties.jumpForce;
        gravityForce = PlayerProperties.gravityForce;
        distanceToGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
    }

    void Update()
    {        
        if (!GameProperties.isPaused)
        {
            if (Input.GetAxis("RTJump") > 0 && Mathf.Abs(rb.velocity.y) < 0.001f && isGrounded)
            {
                PlayerProperties.isStickActive = false;
                
                PlayerProperties.speedForce = 100f;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            if (Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                PlayerProperties.speedForce = 120f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.y) > 0.001f && !PlayerProperties.isStickActive)
        {
            rb.velocity += Vector2.down * gravityForce * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + 0.1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = false;
    }
}
