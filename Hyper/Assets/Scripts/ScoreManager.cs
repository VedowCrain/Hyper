using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Text scoreText, highScoreText;
    private int score;

    public List<HighScore> highScores = new List<HighScore>();

    string dataPath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    internal int GetScore()
    {
        return score;
    }

    void Start()
    {
        //keep reference to the data path on the drive
        dataPath = Path.Combine(Application.persistentDataPath, "highScores.csv");
        print(dataPath);

        LoadScores();

        score = 0;
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        scoreText.text = score.ToString();
        
    }

    void HighScoreUpdate()
    {
        highScoreText.text = "";

        foreach (HighScore hs in highScores)
        {
            highScoreText.text += string.Format("{0} {1}{2}", hs.name, hs.score, System.Environment.NewLine);
        }
    }

    public void Addscore()
    {
        score+=10;
        ScoreUpdate();
    }

    internal void AddHighScore(string playerName)
    {
        highScores.Add(new HighScore(playerName, score));

        SaveScore();
        
    }

    void SaveScore()
    {
        SortList();
        using (StreamWriter file = new StreamWriter(dataPath, false))
        {
            foreach (HighScore hs in highScores)
            {
                file.WriteLine(hs.SerializedString());
            }
        }
    }

    void LoadScores()
    {
        highScores.Clear();

        using (StreamReader reader = new StreamReader(dataPath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                                                        //THIS COULD BREAK IF ITS
                                                        //NOT AN INT VALUE!!!!!
                HighScore hs = new HighScore(values[0], int.Parse(values[1]));

                highScores.Add(hs);
            }
        }
        SortList();
        HighScoreUpdate();
    }

    void SortList()
    {
        highScores = highScores.OrderByDescending(hs => hs.score).ToList();
        highScores = highScores.Take(10).ToList();
    }


}
