using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] string playerName;
    public static PersistentData Instance;
    private int EnterLevelScore;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        playerName = "Player";
        playerScore = 0;
    }
    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }
    public void SetEnterLevelScore(int eScore)
    {
         EnterLevelScore = eScore;
    }
    public int GetEnterLevelScore()
    {
        return EnterLevelScore;
    }
}
