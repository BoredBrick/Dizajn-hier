using System.Collections.Generic;
using UnityEngine;

public class HighscoreDisplayManager : MonoBehaviour
{
    [SerializeField] private HighscoreDisplayRow[] highScoreDisplayArray;
    private List<int> score;

    private void Awake()
    {
        score = GetComponent<XMLHighscoreManager>().HighScores;
    }
    public void ShowScore()
    {
        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < score.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(score[i]);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
    }
}