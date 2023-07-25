using System;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;
using UnityEngine.Localization.Settings;

namespace Pinbattlers.Menus
{
    public class OptionsMenu : MonoBehaviour
    {
        private int m_currentActiveSessionID;
        private GameObject[] m_sessions;

        private AudioMixer m_mixer;

        [Inject]
        void Contructor(GameObject[] sessions, AudioMixer mixer)
        {
            m_sessions = sessions;
            m_mixer = mixer;
            ChangeActiveSession(0);
        }

        public void ChangeActiveSession(int sessionIndex)
        {
            if (m_currentActiveSessionID != sessionIndex)
            {
                m_sessions[sessionIndex].SetActive(true);
                m_sessions[m_currentActiveSessionID].SetActive(false);
                m_currentActiveSessionID = sessionIndex;
            }
        }

        public void OnLanguageDropdownValueChange(int localeIndex)
        {
            LocalizationSettings.Instance.SetSelectedLocale(((LocalesProvider)LocalizationSettings.AvailableLocales).Locales[localeIndex]);
        }

        public void OnEraseSaveButtonClick(string actionName)
        {

        }

        public void OnResolutionDropdownValueChange(int resolutionIndex)
        {
            Screen.SetResolution(Screen.resolutions[resolutionIndex].width, Screen.resolutions[resolutionIndex].height, Screen.fullScreen);
        }

        public void OnGraphicsQualityDropdownValueChange(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex, true);
        }

        public void OnFullscreenToggleValueChange(bool state)
        {
            Screen.fullScreen = state;
        }

        public void OnMasterVolumeSliderValueChange(Single volume)
        {
            m_mixer.SetFloat("Master", volume);
        }

        public void OnMusicVolumeSliderValueChange(Single volume)
        {
            m_mixer.SetFloat("Music", volume);
        }

        public void OnSFXVolumeSliderValueChange(Single volume)
        {
            m_mixer.SetFloat("SFX", volume);
        }
    }
}