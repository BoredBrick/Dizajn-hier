using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.position.y < -20 || transform.position.y < -20)        // Matusou kod mi nefungoval tak som si tam dovolil pridat tu cast s transform
        {
            if (PlayerProperties.playerLifes > 0)
            {
                PlayerProperties.playerLifes--;
                rb.position = new Vector2(-15f, 15f);
                transform.position = new Vector3(0, 0, 0);
            } 
            else
            {
                GameProperties.isEnd = true;
            }         
        }
    }
}
