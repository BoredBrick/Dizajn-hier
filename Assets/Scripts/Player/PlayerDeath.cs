using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private readonly int deathHeight = -100;
    private Vector3 respawnPosition = new(0f, 10f, 0f);

    void Update()
    {
        if (transform.position.y < deathHeight)
        {
            if (PlayerProperties.playerLifes > 0)
            {
                respawnPosition = PlayerProperties.Checkpoint; 
                PlayerProperties.playerLifes--;
                transform.position = respawnPosition;
            }
            else
            {
                GameProperties.isEnd = true;
            }
        }
        else if (WaterRise.WaterPos.y > transform.position.y - 100) 
        {
            GameProperties.isEnd = true;
        }
    }
}
