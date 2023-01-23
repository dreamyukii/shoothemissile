using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMenu : MonoBehaviour
{
    [SerializeField] Slider sliderVolume;
    void Start()
    {
        if (!PlayerPrefs.HasKey("volumeGame"))
        {
            PlayerPrefs.SetFloat("volumeGame",1);
            loadVolume();
        }
        else
        {
            loadVolume();
        }
    }

    public void volumeChange()
    {
        AudioListener.volume = sliderVolume.value;
        saveVolume();
    }

    private void loadVolume()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("volumeGame");
    }

    private void saveVolume()
    {
        PlayerPrefs.SetFloat("volumeGame",sliderVolume.value);
    }
}
