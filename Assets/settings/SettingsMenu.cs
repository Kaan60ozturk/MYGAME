using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        // Önceki ayarlarý slider'a yansýt
        if (AudioManager.instance != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

            // Listener ekle
            musicSlider.onValueChanged.AddListener(AudioManager.instance.SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(AudioManager.instance.SetSFXVolume);
        }
    }
}
