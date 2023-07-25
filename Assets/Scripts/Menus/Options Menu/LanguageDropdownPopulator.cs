using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Pinbattlers.Menus
{
    public class LanguageDropdownPopulator : MonoBehaviour
    {
        TMP_Dropdown m_dropdown;

        void Start()
        {
            m_dropdown = GetComponent<TMP_Dropdown>();
            List<string> list = new List<string>();
            LocalesProvider locales = (LocalesProvider)LocalizationSettings.AvailableLocales;

            foreach (Locale l in locales.Locales)
            {
                list.Add(l.name);
            }

            m_dropdown.AddOptions(list);

            Invoke(nameof(UpdateValue), 1);
        }

        IEnumerator UpdateValue()
        {
            yield return new WaitForSeconds(1f);

            LocalesProvider locales = (LocalesProvider)LocalizationSettings.AvailableLocales;
            foreach (Locale l in locales.Locales)
            {
                if (l == LocalizationSettings.Instance.GetSelectedLocale())
                {
                    m_dropdown.value = locales.Locales.IndexOf(l);
                    m_dropdown.RefreshShownValue();
                }
            }
        }
    }
}
