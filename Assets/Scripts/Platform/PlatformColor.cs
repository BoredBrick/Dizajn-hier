using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Color platformColor;
    private new SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Colors.GetRandomColor();
        platformColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.gameObject.GetComponent<Collider2D>();
        if (PlayerProperties.playerColor.Equals(platformColor))
            collider.isTrigger = false;
        else
        {
            collider.isTrigger = true;
            //player.transform.SetParent(null); TODO PRECO???
        }
    }
}
