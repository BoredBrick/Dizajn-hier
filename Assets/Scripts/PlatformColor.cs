using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Color platformColor;

    Color green = new(0.4334f, 0.78f, 0.234f);
    Color red = new(0.8117647f, 0.1803922f, 0.1764706f);
    Color yellow = new(0.9019608f, 0.8f, 0.1215686f);
    Color blue = new(0.01176471f, 0.6509804f, 0.8901961f);

    private void Start()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().color = green;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().color = red;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().color = blue;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().color = yellow;
                break;
        }
        platformColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        if (PlayerProperties.playerColor.Equals(platformColor))
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        else
        {
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            player.transform.SetParent(null);
        }            
    }
}
