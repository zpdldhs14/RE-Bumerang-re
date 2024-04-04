using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.1f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        float volume = volumeSlider.value;
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
        Save();
    }

    private void Save()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Load()
    {
    float volume = PlayerPrefs.GetFloat("musicVolume", 0.1f);
    volumeSlider.value = volume;
    AudioListener.volume = volume;
    }
}
