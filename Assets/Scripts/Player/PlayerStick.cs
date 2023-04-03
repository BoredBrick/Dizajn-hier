using System;
using UnityEngine;

public class PlayerStick : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speedForce;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        speedForce = PlayerProperties.speedForce;
    }

    void Update() {
        if (Input.GetAxis("LTStick") > 0 && PlayerProperties.isStickActive)
        {
            if (PlayerProperties.stickLength >= 0)
            {
                PlayerProperties.stickLength -= Time.deltaTime;

                rb.gravityScale = 0f;
                float moveVertical = Input.GetAxis("Vertical");
                Vector2 movement = new(0f, moveVertical);
                transform.Translate(speedForce * Time.deltaTime * movement, Space.World);
            }
        }

        if (Input.GetAxis("LTStick") == 0 || PlayerProperties.stickLength <= 0 || !PlayerProperties.isStickActive)
        {
            rb.gravityScale = 1.0f;
        }

        if (Input.GetAxis("LTStick") == 0 && Math.Round(Constants.stickLength - PlayerProperties.stickLength) > 1)
        {
            if (PlayerProperties.stickCooldown >= 0)
            {
                PlayerProperties.stickCooldown -= Time.deltaTime;
            }
        }

        if (PlayerProperties.stickCooldown <= 0)
        {
            PlayerProperties.stickLength++;
            PlayerProperties.stickCooldown = Constants.stickCooldown;
        }
    }

}
