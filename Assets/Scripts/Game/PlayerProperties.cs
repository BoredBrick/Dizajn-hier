using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static float speedForce = 120f;
    public static float jumpForce = 150f;
    public static float gravityForce = 300f;
    public static Color playerColor;
    public static bool isStickActive = false;
    public static float stickLength = 80f;
    public static float stickCooldown = 2f;
    public static float colorChangeCooldown = 10f;
    public static float colorChangeCountdown = 10f;
    public static int playerLifes = 3;

    public static int playerGems = 0;
}
