using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResume : MonoBehaviour
{
    public Image pauseSprite;
    public Button pauseButton;
    public Button resumeButton;
    void Start()
    {
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        pauseSprite.enabled = false;

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        pauseSprite.enabled = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        pauseSprite.enabled = false;
    }
}
