using UnityEngine;

public class Background : MonoBehaviour
{
    private float startPosX, startPosY;
    [SerializeField] GameObject camera;
    void Start()
    {
        //startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    void Update()
    {
        //float distanceX = camera.transform.position.x;
        float distanceY = camera.transform.position.y;
        transform.position = new Vector3(
            transform.position.x,
            startPosY + (distanceY / 0.8f), 
            transform.position.z);
    }
}
