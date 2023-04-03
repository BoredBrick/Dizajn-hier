using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    Color originalColor;
    float originalColorChangeCooldown;
    float originalColorChangeCountdown;

    Color green = new(0.4334f, 0.78f, 0.234f);
    Color red = new(0.8117647f, 0.1803922f, 0.1764706f);
    Color yellow = new(0.9019608f, 0.8f, 0.1215686f);
    Color blue = new(0.01176471f, 0.6509804f, 0.8901961f);

    void Start()
    {
        PlayerProperties.playerColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        originalColor = PlayerProperties.playerColor;
        originalColorChangeCooldown = PlayerProperties.colorChangeCooldown;
        originalColorChangeCountdown = PlayerProperties.colorChangeCountdown;
    }

    void Update()
    {
        if (Input.GetButtonDown("AButtonGreen") && PlayerProperties.playerColor != Color.green)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = green;
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        if (Input.GetButtonDown("BButtonRed") && PlayerProperties.playerColor != Color.red)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = red;
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        if (Input.GetButtonDown("XButtonBlue") && PlayerProperties.playerColor != Color.blue)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = blue;
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        if (Input.GetButtonDown("YButtonYellow") && PlayerProperties.playerColor != Color.yellow)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = yellow;
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        PlayerProperties.playerColor = gameObject.GetComponent<SpriteRenderer>().color;        

        if (PlayerProperties.colorChangeCooldown >= 0)
        {
            PlayerProperties.colorChangeCooldown -= Time.deltaTime;
        }

        if (PlayerProperties.colorChangeCooldown <= 0 && PlayerProperties.colorChangeCountdown >= 0)
        {
            PlayerProperties.colorChangeCountdown -= Time.deltaTime;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(PlayerProperties.playerColor, originalColor, Time.deltaTime / (originalColorChangeCountdown / 2));
        }        
    }
}
