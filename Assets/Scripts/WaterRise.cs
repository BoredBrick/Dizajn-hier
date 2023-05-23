using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaterRise : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float waterSpeed = 5f;
    float waterX, waterY = -200;
    public static Vector3 waterPos;

    void Update()
    {
        waterX = player.transform.position.x;
        waterY = waterY + ((waterSpeed / 500));
        transform.position = new Vector2(waterX, waterY);
        waterPos = transform.position;
    }
}
