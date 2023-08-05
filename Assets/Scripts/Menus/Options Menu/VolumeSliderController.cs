using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

public class VolumeSliderController : MonoBehaviour
{
    private enum SoundType
    {
        Master,
        Music,
        SFX
    }

    [SerializeField] private SoundType m_soundType;

    [Inject]
    [SerializeField] private AudioMixer m_audioMixer;

    private void Start()
    {
        Slider slider = GetComponent<Slider>();

        float value;
        if (m_soundType == SoundType.Master)
        {
            m_audioMixer.GetFloat("Master", out value);
            slider.value = value;
        }
        else if (m_soundType == SoundType.Music)
        {
            m_audioMixer.GetFloat("Music", out value);
            slider.value = value;
        }
        else
        {
            m_audioMixer.GetFloat("SFX", out value);
            slider.value = value;
        }
    }

    public void SetSoundValue(float value)
    {
        if (m_soundType == SoundType.Master)
        {
            m_audioMixer.SetFloat("Master", value);
            PlayerPrefs.SetFloat("MasterVolume", value);
        }
        else if (m_soundType == SoundType.Music)
        {
            m_audioMixer.SetFloat("Music", value);
            PlayerPrefs.SetFloat("MusicVolume", value);
        }
        else
        {
            m_audioMixer.SetFloat("SFX", value);
            PlayerPrefs.SetFloat("SFXVolume", value);
        }
    }
}