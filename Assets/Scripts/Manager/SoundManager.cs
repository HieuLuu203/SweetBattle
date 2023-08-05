using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void VolumeChange()
    {
        AudioListener.volume = volumeSlider.value;  
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    /*private void UpdateButtonIcon()
    {
        if (muted)
        {
            SoundOnIcon.enabled = false;
            SoundOffIcon.enabled = true;
        }
        else
        {
            SoundOnIcon.enabled = true;
            SoundOffIcon.enabled = false;
        }

    }
    public void OnButtonPress()
    {
        if (muted)
        {
            muted = false;
            AudioListener.pause = false;
            Debug.Log(muted);
        }
        else
        {
            muted = true;
            AudioListener.pause = true;
        }
        Save();
        UpdateButtonIcon();
    }*/
}
