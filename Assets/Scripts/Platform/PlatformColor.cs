using System.Collections;
using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Color playerColor;
    [SerializeField] Color platformColor;
    [SerializeField] Color currentPlayerColor;
    private new SpriteRenderer renderer;
    private new Collider2D collider;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Colors.GetRandomColor();
        playerColor = player.GetComponent<SpriteRenderer>().color;
        platformColor = gameObject.GetComponent<SpriteRenderer>().color;
        currentPlayerColor = PlayerProperties.playerColor;
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (currentPlayerColor != PlayerProperties.playerColor)
        {
            currentPlayerColor = PlayerProperties.playerColor;

            if (PlayerProperties.playerColor.Equals(platformColor) && !PlayerProperties.playerColor.Equals(playerColor))
            {
                StartCoroutine(WaitForX(10f));
                collider.enabled = true;
            }
            else
            {
                collider.enabled = false;
            }
        }
    }

    IEnumerator WaitForX(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCollision(collision.collider);
    }
    private void CheckCollision(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")
            && PlayerProperties.playerColor.Equals(platformColor)
            && !PlayerProperties.playerColor.Equals(playerColor))
        {
            this.collider.enabled = true;
        }
        else if (!this.collider.isTrigger)
        {
            this.collider.enabled = false;
        }
    }
}