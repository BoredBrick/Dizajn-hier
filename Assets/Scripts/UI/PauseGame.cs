using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseScreen;
    //TODO Pridat osetrenie na pauznutie len v hre + dorobit pause screen

    private void Start()
    {
        pauseScreen.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("StartButtonPause"))
        {
            if (pauseScreen.activeSelf)
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
        }
    }
}
