using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public static bool isPlayerClose = false;
    private GameObject player;
    private GameObject mainCamera;
    private float distanceThreshold = 70f;
    private float travelDistance = 50f;
    private float movementSpeed = 30f;
    private Rigidbody2D rb;
    private float defaultPosition;  

    void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("MainCamera");
        defaultPosition = this.gameObject.transform.localPosition.x;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = player.GetComponent<Rigidbody2D>().position.x - rb.position.x;

        if (Mathf.Abs(distance) >= distanceThreshold)
        {
            isPlayerClose = false;

            if (Mathf.Round(this.gameObject.transform.eulerAngles.y) == 0 && this.gameObject.transform.localPosition.x >= (defaultPosition - travelDistance))
            {
                transform.Translate(Vector2.left * Time.deltaTime * movementSpeed, Space.World);
            }

            if (Mathf.Round(this.gameObject.transform.eulerAngles.y) == 180 && this.gameObject.transform.localPosition.x <= (defaultPosition + travelDistance))
            {
                transform.Translate(Vector2.right * Time.deltaTime * movementSpeed, Space.World);
            }

            if (this.gameObject.transform.localPosition.x <= (defaultPosition - travelDistance))
            {
                transform.eulerAngles = new Vector3(0, 180, 90);
            }

            if (this.gameObject.transform.localPosition.x >= (defaultPosition + travelDistance))
            {
                transform.eulerAngles = new Vector3(0, 0, 90); 
            }
        }
        else
        {
            isPlayerClose = true;

            if (Mathf.Round(this.gameObject.transform.eulerAngles.y) == 0 && player.GetComponent<Rigidbody2D>().position.x >= rb.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 90);
            }

            if (Mathf.Round(this.gameObject.transform.eulerAngles.y) == 180 && player.GetComponent<Rigidbody2D>().position.x <= rb.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
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
        }
    }
}
