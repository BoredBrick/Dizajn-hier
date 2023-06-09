using UnityEngine;
//TODO UPRATAT
public class PlatformProperties : MonoBehaviour
{
    public AudioSource crackSFX;
    [SerializeField] private bool isStickable = false;
    [SerializeField] private bool isBreakable = false;
    [SerializeField] private bool isBroken = false;
    [SerializeField] private int chanceToBreak = 80;
    [SerializeField] private float timeToBreak = 1f;
    [SerializeField] private float timeToRespawn = 3f;
    [SerializeField] private Sprite brokenPlatform;

    private int rnd;

    private void Start()
    {
        if (isBreakable)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            rnd = Random.Range(0, 100);

            if (rnd < chanceToBreak)
            {
                spriteRenderer.sprite = brokenPlatform;
                Color color = new(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.8f);
                spriteRenderer.color = color;
            }
        }
    }

    private void Update()
    {
        if (isBroken)
        {
            if (timeToBreak >= 0)
            {
                timeToBreak -= Time.deltaTime;
            }

            if (timeToBreak <= 0)
            {
                BreakPlatform();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBreakable && rnd < chanceToBreak)
        {
            if (!crackSFX.isPlaying)
            {
                crackSFX.Play();
            }

            isBroken = true;
        }

        if (collision.gameObject.CompareTag("Player") && this.isStickable)
        {
            PlayerProperties.isStickActive = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.isStickable)
        {
            PlayerProperties.isStickActive = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBreakable && rnd < chanceToBreak)
        {
            crackSFX.Stop();
        }

        if (collision.gameObject.CompareTag("Player") && this.isStickable)
        {
            PlayerProperties.isStickActive = false;
        }       
    }

    private void BreakPlatform()
    {
        crackSFX.Stop();

        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;

        if (timeToRespawn >= 0)
        {
            timeToRespawn -= Time.deltaTime;
        }

        if (timeToRespawn <= 0)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Collider2D>().enabled = true;
            timeToBreak = 1f;
            timeToRespawn = 3f;
            isBroken = false;
        }
    }

    public bool GetIsStickable()
    {
        return isStickable;
    }
}
