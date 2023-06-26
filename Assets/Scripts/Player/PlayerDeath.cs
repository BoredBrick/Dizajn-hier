using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    private readonly int deathHeight = -100;
    private readonly Vector3 respawnPosition = new(0f, 10f, 0f);
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject newGameButton;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private Image menuButtonImage;
    [SerializeField] private Image newGameButtonImage;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject controller;
    private XMLHighscoreManager HighscoreManager;
    private bool respawned = false;

    private void Start()
    {
        HighscoreManager = controller.GetComponent<XMLHighscoreManager>();
    }
    private void Update()
    {
        if (GameProperties.isPaused)
        {
            return;
        }

        if (!HitTaken(null))
        {
            return;
        }

        if (PlayerProperties.lives > 1)
        {
            PlayerProperties.lives--;
            transform.position = respawnPosition;
            WaterRise.WaterPos = new Vector2(transform.position.x, WaterRise.WaterPos.y - 300);
            respawned = false;
        }
        else
        {
            Time.timeScale = 0;
            deathScreen.SetActive(true);
            HighscoreManager.AddScore(PlayerProperties.score);
            scoreText.text = "Score: " + PlayerProperties.score.ToString();
            SetToPlayerColors();
            GameProperties.isPaused = true;
            GameProperties.isEnded = true;
            EventSystem.current.SetSelectedGameObject(newGameButton);
        }
    }

    private bool HitTaken(Collider2D collision)
    {
        /*
        if (transform.position.y < deathHeight)
        {
            return true;
        }
        */
        
        if (collision != null && collision.CompareTag("Respawn") && respawned == false)
        {
            respawned = true;
        }        
        else if (WaterRise.WaterPos.y > transform.position.y - 80)
        {
            //PlayerProperties.lives = 0;
            return true;
        }
        return false;
    }

    private void SetToPlayerColors()
    {
        Color color = PlayerProperties.playerColor;
        menuButtonImage.color = color;
        newGameButtonImage.color = color;
        gameOverText.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitTaken(collision);
    }
}
