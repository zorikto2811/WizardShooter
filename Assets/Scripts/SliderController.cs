using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixerGroup musicMixer;
    [SerializeField] private AudioMixerGroup soundMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("Music");
        }
        else
        {
            musicSlider.value = 0;
        }

        if (PlayerPrefs.HasKey("Sound"))
        {
            soundSlider.value = PlayerPrefs.GetFloat("Sound");
        }
        else
        {
            soundSlider.value = 0;
        }
    }

    public void ChangeMusicVolume()
    {
        SetAudioVolume(musicSlider, musicMixer);
    }

    public void ChangeSoundVolume()
    {
        SetAudioVolume(soundSlider, soundMixer);
    }

    private void SetAudioVolume(Slider slider, AudioMixerGroup audio)
    {
        float volume = slider.value;
        audioMixer.SetFloat(audio.name, volume);
        PlayerPrefs.SetFloat(audio.name, volume);
    }
}
