using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private readonly int deathHeight = -100;
    private readonly Vector3 respawnPosition = new(0f, 0f, 0f);
    [SerializeField] private GameObject deathScreen;

    void Update()
    {
        if (transform.position.y < deathHeight)
        {
            if (PlayerProperties.playerLifes > 0)
            {
                PlayerProperties.playerLifes--;
                transform.position = respawnPosition;
            }
            else
            {
                Time.timeScale = 0;
                deathScreen.SetActive(true);
                GameProperties.isEnd = true;
            }
        }
    }
}
