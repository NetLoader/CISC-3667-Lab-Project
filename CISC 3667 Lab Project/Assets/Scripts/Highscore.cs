using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public int totalScore = 5;
    public string nameKey = "Player";
    public string scoreKey = "Score";
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] Text[] nameList;
    [SerializeField] Text[] scoreList;

    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        playerScore = PersistentData.Instance.GetScore();
        SaveScore();
        DisplayHighScore();
    }
    public void SaveScore()
    {
        for (int i = 1; i <= totalScore; i++)
        {
            string currentNameKey = nameKey + i;
            string currentScoreKey = scoreKey + i;

            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                if (playerScore > currentScore)
                {
                    int tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);

                    playerName = tempName;
                    playerScore = tempScore;
                }
            }
            else 
            {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                return;
            }
        }
    }
    public void DisplayHighScore()
    {
        for (int i = 0; i < totalScore; i++)
        {
            nameList[i].text = PlayerPrefs.GetString(nameKey + (i + 1));
            scoreList[i].text = PlayerPrefs.GetInt(scoreKey + (i + 1)).ToString();
        }
    }
}
