using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Kaydedilmiþ ses ayarlarýný yükle
            float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
            float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

            SetMusicVolume(musicVol);
            SetSFXVolume(sfxVol);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Müzik sesini ayarla ve kaydet
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("MusicVolume", musicSource.volume);
    }

    // Efekt sesini ayarla ve kaydet
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("SFXVolume", sfxSource.volume);
    }


}