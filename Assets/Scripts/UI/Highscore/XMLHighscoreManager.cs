using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XMLHighscoreManager : MonoBehaviour
{
    private Leaderboard leaderboard;
    private readonly string HighScoresXMLFilePath = "/Highscores/highscores.xml";
    private readonly string HighScoresXMLFolderPath = "/Highscores/";
    public List<int> HighScores { get; } = new();

    void Awake()
    {
        if (!Directory.Exists(Application.persistentDataPath + HighScoresXMLFolderPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath + HighScoresXMLFolderPath);
        }
        HighScores.Add(3);
        HighScores.Add(432);
        SaveScores(HighScores);
    }

    public void SaveScores(List<int> scores)
    {
        leaderboard = new() { };
        leaderboard.Entries.AddRange(scores);
        XmlSerializer serializer = new(typeof(Leaderboard));
        FileStream stream = new(Application.persistentDataPath + HighScoresXMLFilePath, FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();
    }

    public List<int> LoadScores()
    {
        List<int> scores = new();
        if (File.Exists(Application.persistentDataPath + HighScoresXMLFilePath))
        {
            XmlSerializer serializer = new(typeof(Leaderboard));
            FileStream stream = new(Application.persistentDataPath + HighScoresXMLFilePath, FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
            scores.AddRange(leaderboard.Entries);
        }
        return scores;
    }

    [System.Serializable]
    private class Leaderboard
    {
        public List<int> Entries { get; } = new();
    }
}