using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("bgmVolume"))
        {
            PlayerPrefs.SetFloat("bgmVolume", 0.8f);
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
        
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("bgmVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("bgmVolume", volumeSlider.value);
    }
}
