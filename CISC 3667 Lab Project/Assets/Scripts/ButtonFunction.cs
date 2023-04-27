using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;

    void Start()
    {
        playerNameInput.text = PersistentData.Instance.GetName();
    }
    public void PlayGame()
    {
        string playerName = playerNameInput.text;
        PersistentData.Instance.SetName(playerName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
