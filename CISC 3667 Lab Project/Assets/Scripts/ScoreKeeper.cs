using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;
    private int score;

    private void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}