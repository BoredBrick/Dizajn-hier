using System.Collections;
using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color platformColor;
    private Color CurrentPlayerColor { get; set; }
    private new SpriteRenderer renderer;
    private new Collider2D collider;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Colors.GetRandomColor();
        defaultColor = player.GetComponent<SpriteRenderer>().color;
        platformColor = gameObject.GetComponent<SpriteRenderer>().color;
        CurrentPlayerColor = PlayerProperties.playerColor;
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Debug.Log(PlayerProperties.displayedColor);
        if ((PlayerProperties.playerColor == PlayerProperties.displayedColor)
            &&  PlayerProperties.playerColor == platformColor)
        {
            collider.enabled = true;
            return;
        }

        if (PlayerProperties.playerColor != platformColor)
        {
            collider.enabled = false;
            return;
        }

        //zacina blednutie
        if (PlayerProperties.playerColor != PlayerProperties.displayedColor)
        {
            collider.enabled = true;

        }

        /*
        if (CurrentPlayerColor != PlayerProperties.playerColor)
        {
            CurrentPlayerColor = PlayerProperties.playerColor;

            if (PlayerProperties.playerColor.Equals(platformColor)
                && !PlayerProperties.playerColor.Equals(defaultColor))
            {
                //StartCoroutine(WaitForX(10f));
                collider.enabled = true;
            }
            else
            {
                collider.enabled = false;
            }
        }
        */
    }

    IEnumerator WaitForX(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCollision(collision.collider);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CheckCollision(collision.collider);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CheckCollision(collision.collider);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void CheckCollision(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")
            && PlayerProperties.playerColor.Equals(platformColor))
        {
            this.collider.enabled = true;
        }
        else if (!this.collider.isTrigger)
        {
            this.collider.enabled = false;
        }
    }
}