using System;
using UnityEngine;

public class PlayerStick : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speedForce;
    private readonly float fullStickTime = 8f;
    private readonly float timeUntilStickRegen = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedForce = PlayerProperties.speedForce;
    }

    void Update()
    {
        if (Input.GetAxis("LTStick") > 0 && PlayerProperties.isStickActive)
        {
            if (PlayerProperties.remainingStickTime >= 0)
            {
                PlayerProperties.remainingStickTime -= Time.deltaTime;

                rb.gravityScale = 0f;
                rb.velocity = Vector3.zero;
                float moveVertical = Input.GetAxis("Vertical");
                Vector2 movement = new(0f, moveVertical);
                transform.Translate(speedForce * Time.deltaTime * movement, Space.World);
            }
        }

        if (Input.GetAxis("LTStick") == 0 && PlayerProperties.isStickActive)
        {
            rb.velocity += PlayerProperties.gravityForce * Time.deltaTime * Vector2.down;
        }

        if (Input.GetAxis("LTStick") == 0 || PlayerProperties.remainingStickTime <= 0 || !PlayerProperties.isStickActive)
        {
            rb.gravityScale = 1f;
        }

        if (Input.GetAxis("LTStick") == 0 && Math.Round(fullStickTime - PlayerProperties.remainingStickTime) > 1)
        {
            if (PlayerProperties.timeUntilStickRegen >= 0)
            {
                PlayerProperties.timeUntilStickRegen -= Time.deltaTime;
            }
        }

        if (PlayerProperties.timeUntilStickRegen <= 0)
        {
            PlayerProperties.remainingStickTime++;
            PlayerProperties.timeUntilStickRegen = timeUntilStickRegen;
        }
    }

}
