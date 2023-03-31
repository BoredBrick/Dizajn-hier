using UnityEngine;

public class PlatformOneTouch : MonoBehaviour
{
    [SerializeField] private short chanceToBreak = 40;
    [SerializeField] private float tiemToBreak = .5f;
    short rnd;
    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        rnd = (short)Random.Range(0, 100);

        if (rnd < chanceToBreak)
            spriteRenderer.color = new (0, 0, 0, 0.5f);
        /*
         * Dobuducna na nastavenie ineho spritu pre oneTouch plosinu
         
        if (rnd < oneTouchChance)
            spriteRenderer.sprite = 
        */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rnd < chanceToBreak)
            Invoke(nameof(BreakPlatform), tiemToBreak);
    }
    private void BreakPlatform() 
    {         
        gameObject.SetActive(false);
    }
}
