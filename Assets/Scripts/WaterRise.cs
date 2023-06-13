using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaterRise : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float waterSpeed = 5f;
    float waterX, waterY = -120;
    public static Vector3 waterPos;

    private void Start()
    {
        waterSpeed /= 300;
    }

    void Update()
    {
        if (PlayerProperties.distance == SectionGenerator.breakPoint1 || 
            PlayerProperties.distance == SectionGenerator.breakPoint2 || 
            PlayerProperties.distance == SectionGenerator.breakPoint3)
            RiseWatterSpeed(waterSpeed);

        waterX = player.transform.position.x;
        waterY = waterY + waterSpeed;
        transform.position = new Vector2(waterX, waterY);
        waterPos = transform.position;
    }
    public float RiseWatterSpeed(float speed)
    {
        return speed * 2;
    }
}
