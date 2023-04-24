using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int scoreThreshold;
    private ScoreKeeper sk;
    private int score;

    private void Start()
    {
        sk = FindObjectOfType<ScoreKeeper>();
    }
    private void Update()
    {
        score = sk.TotalBalloonPopped();
        if (score >= scoreThreshold )
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}