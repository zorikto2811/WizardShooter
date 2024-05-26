using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioInGame : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixerGroup musicMixer;
    [SerializeField] private AudioMixerGroup soundMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            audioMixer.SetFloat(musicMixer.name, PlayerPrefs.GetFloat("Music"));
        }
        else
        { 
            audioMixer.SetFloat (musicMixer.name, 0f);
        }

        if (PlayerPrefs.HasKey("Sound"))
        {
            audioMixer.SetFloat(soundMixer.name, PlayerPrefs.GetFloat("Sound"));
        }
        else
        {
            audioMixer.SetFloat(soundMixer.name, 0f);
        }
    }
}
