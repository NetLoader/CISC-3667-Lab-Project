using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
