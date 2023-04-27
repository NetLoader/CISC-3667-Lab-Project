using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;
    private int score;
    private int totalBalloonPopped;

    private void Start()
    {
        score = PersistentData.Instance.GetScore();
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        PersistentData.Instance.SetScore(score);
        totalBalloonPopped++;
        scoreText.text = "Score: " + score.ToString();
    }
    public int TotalBalloonPopped()
    {
        return totalBalloonPopped;
    }
}
