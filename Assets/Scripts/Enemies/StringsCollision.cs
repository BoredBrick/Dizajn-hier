using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringsCollision : MonoBehaviour
{
    private GameObject player;
    private GameObject mainCamera;
    private float remainingForceTime = 0.4f;
    private bool wasCorrectColor = false;

    void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("MainCamera");
    }

    void Update()
    {
        if (wasCorrectColor) 
        {
            
            if (remainingForceTime >= 0)
            {
                remainingForceTime -= Time.deltaTime;
            }

            if (remainingForceTime <= 0)
            {
                wasCorrectColor = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                remainingForceTime = 0.4f;                
            }         
        }

        if (mainCamera.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainCamera.GetComponent<Animator>().IsInTransition(0))
        {
            Animator animation = mainCamera.GetComponent<Animator>().GetComponentInChildren<Animator>();
            animation.Rebind();
            animation.Update(0f);
            mainCamera.GetComponent<Animator>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerProperties.playerColor == this.gameObject.GetComponent<SpriteRenderer>().color)
            {
                wasCorrectColor = true;

                this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                mainCamera.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
                mainCamera.GetComponent<Animator>().enabled = true;

                if (PlayerProperties.playerLifes > 0)
                {
                    PlayerProperties.playerLifes--;
                    player.transform.position = new(0f, 10f, 0f);
                }
                else
                {
                    GameProperties.isEnd = true;
                }

                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                this.gameObject.SetActive(false);
            }
        }
    }
}
