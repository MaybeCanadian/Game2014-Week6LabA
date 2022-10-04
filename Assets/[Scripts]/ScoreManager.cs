using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreLabel();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int input)
    {
        score = input;
        UpdateScoreLabel();
    }

    public void AddScore(int input)
    {
        score += input;
        UpdateScoreLabel();
    }

    public void UpdateScoreLabel()
    {
        scoreLabel.text = "Score: " + score.ToString();
    }
}
