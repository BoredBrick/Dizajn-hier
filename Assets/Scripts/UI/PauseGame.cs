using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Image resumeButton;
    [SerializeField] private Image menuButton;
    [SerializeField] private TMP_Text pausedText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("StartButtonPause"))
        {
            if (pauseScreen.activeSelf)
            {
                Unpause();
            }
            else
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                SetToPlayerColors();
                GameProperties.isPaused = true;
            }
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        GameProperties.isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void SetToPlayerColors()
    {
        Color color = PlayerProperties.playerColor;
        resumeButton.color = color;
        menuButton.color = color;
        pausedText.color = color;
    }
}
