using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private readonly int deathHeight = -100;
    private static readonly Vector3 respawnPosition = new(0f, 10f, 0f);


    void Update()
    {
        if (transform.position.y < deathHeight)
        {
            if (PlayerProperties.playerLifes > 0)
            {
                //respawnPosition = PlayerProperties.GetCheckpoint();  Pojde po refaktore
                PlayerProperties.playerLifes--;
                transform.position = respawnPosition;
            }
            else
            {
                GameProperties.isEnd = true;
            }
        }
    }
}
