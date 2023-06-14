using UnityEngine;

public class WaterRise : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float defaultSpeed = 5f, diff;
    float speed1, speed2, speed3, speed4, speed5;
    private static Vector3 waterPos;
    public static Vector3 WaterPos { get { return waterPos; } }

    void Start()
    {
        waterPos = transform.position;
        speed1 = defaultSpeed / 300;
        speed2 = defaultSpeed / 125;
        speed3 = defaultSpeed / 25;
        speed4 = defaultSpeed / 5;
        speed5 = defaultSpeed;
    }

    void Update()
    {
        float
            waterX = player.transform.position.x,
            waterY = transform.position.y,
            speed;
            
        diff = player.transform.position.y - waterY;

        if (diff < 200)
            speed = speed1;
        else if (diff >= 200 && diff < 400)
            speed = speed2;
        else if (diff >= 400 && diff < 600)
            speed = speed3;
        else if (diff >= 600 && diff < 800)
            speed = speed4;
        else
            speed = speed5;

        transform.position = new Vector2(waterX, waterY += speed);
        waterPos = transform.position;
    }
}
