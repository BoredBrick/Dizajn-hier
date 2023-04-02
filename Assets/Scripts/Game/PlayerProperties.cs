using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] public static float speedForce = 80f;
    public static float jumpForce = 70f;
    public static float gravityForce = 80f;
    public static Color playerColor;
    public static bool isStickActive = false;
    public static float stickLength = 80f;
    public static float stickCooldown = 2f;
    public static float colorChangeCooldown = 10f;
    public static float colorChangeCountdown = 10f;
    public static int playerLifes = 3;
}
