using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pinbattlers.Menus
{
    public class GrimoireController : MonoBehaviour
    {
        [SerializeField] private PlayerData m_playerData;

        [SerializeField] private TMP_Text m_abilityName;
        [SerializeField] private Image m_abilityIllustration;
        [SerializeField] private TMP_Text m_abilityLoreDescription;
        [SerializeField] private TMP_Text m_abilityMechanicDescription;
        [SerializeField] private GameObject[] m_levelStars;
        [SerializeField] private TMP_Text m_upgradeCost;

        [SerializeField] private Button m_nextPageButton;
        [SerializeField] private Button m_previousPageButton;
        [SerializeField] private Button m_equipButton;
        [SerializeField] private Button m_upgradeButton;

        private int m_page;

        public void UpdateInfo(int page)
        {
            m_page = page;

            m_abilityName.text = m_playerData.Abilities[m_page].Name;
            m_abilityIllustration.sprite = m_playerData.Abilities[m_page].Icon;
            m_abilityLoreDescription.text = m_playerData.Abilities[m_page].LoreDescription;
            m_abilityMechanicDescription.text = m_playerData.Abilities[m_page].MechanicDescription;

            for (int i = 0; i < m_levelStars.Length; i++)
            {
                if (i + 1 <= m_playerData.Abilities[m_page].Level) m_levelStars[i].SetActive(true);
                else m_levelStars[i].SetActive(false);
            }

            if (m_playerData.AbilityEquiped == m_playerData.Abilities[page]) m_equipButton.interactable = false;
            else m_equipButton.interactable = true;

            m_upgradeCost.text = m_playerData.Abilities[page].Level.ToString();
            if (m_playerData.Stars < m_playerData.Abilities[page].Level) m_upgradeButton.interactable = false;
        }

        public void OnNextPageButtonClick()
        {
            if (m_page + 1 == m_playerData.Abilities.Count - 1) m_nextPageButton.interactable = false;
            if (!m_previousPageButton.interactable) m_previousPageButton.interactable = true;
            UpdateInfo(m_page + 1);
        }

        public void OnPreviousPageButtonClick()
        {
            if (m_page - 1 == 0) m_previousPageButton.interactable = false;
            if (!m_nextPageButton.interactable) m_nextPageButton.interactable = true;
            UpdateInfo(m_page - 1);
        }

        public void OnEquipButtonClick()
        {
            m_playerData.EquipAbility(m_playerData.Abilities[m_page]);
            m_equipButton.interactable = false;
        }

        public void OnUpgradeButtonClick()
        {
            m_playerData.UpgradeAbility(m_page);
            if (m_playerData.Stars < m_playerData.Abilities[m_page].Level) m_upgradeButton.interactable = false;
        }
    }
}