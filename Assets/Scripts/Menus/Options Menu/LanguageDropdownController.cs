using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Pinbattlers.Menus
{
    public class LanguageDropdownController : MonoBehaviour
    {
        private TMP_Dropdown m_dropdown;

        [SerializeField] private LocalizationSettings m_localizationSettings;

        private void Start()
        {
            m_dropdown = GetComponent<TMP_Dropdown>();
            List<string> list = new List<string>();

            foreach (Locale l in m_localizationSettings.GetAvailableLocales().Locales)
            {
                list.Add(l.name);
            }

            m_dropdown.AddOptions(list);

            SetNewLanguageValue(m_localizationSettings.GetAvailableLocales().Locales.IndexOf(m_localizationSettings.GetSelectedLocale()));
        }

        public void SetNewLanguageValue(int languageIndex)
        {
            m_localizationSettings.SetSelectedLocale(m_localizationSettings.GetAvailableLocales().Locales[languageIndex]);
            m_dropdown.value = languageIndex;
            m_dropdown.RefreshShownValue();

            PlayerPrefs.SetInt("Language", languageIndex);
        }
    }
}