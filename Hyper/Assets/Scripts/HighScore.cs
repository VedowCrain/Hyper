

using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HighScore
{

    public int score;
    public string name;

    public HighScore(string name, int score)
    {
        this.score = score;
        this.name = name;
    }

    public string SerializedString()
    {
        return string.Format("{0},{1}", name, score);
    }
    
}
