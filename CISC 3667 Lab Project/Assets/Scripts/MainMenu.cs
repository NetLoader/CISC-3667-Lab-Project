using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGameInMenu()
    {
        SceneManager.LoadScene("EnterName");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }
    public void Instruction()
    {
        SceneManager.LoadScene("Instruction");
    }
    public void ToMenu()
    {
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("Menu");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Keybind()
    {
        SceneManager.LoadScene("Keybind");
    }
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
