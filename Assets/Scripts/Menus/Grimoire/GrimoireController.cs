using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pinbattlers.Menus
{
    public class GrimoireController : MonoBehaviour
    {
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

            m_abilityName.text = PlayerData.Instance.Abilities[m_page].Name;
            m_abilityIllustration.sprite = PlayerData.Instance.Abilities[m_page].Icon;
            m_abilityLoreDescription.text = PlayerData.Instance.Abilities[m_page].LoreDescription;
            m_abilityMechanicDescription.text = PlayerData.Instance.Abilities[m_page].MechanicDescription;

            for (int i = 0; i < m_levelStars.Length; i++)
            {
                if (i + 1 <= PlayerData.Instance.Abilities[m_page].Level) m_levelStars[i].SetActive(true);
                else m_levelStars[i].SetActive(false);
            }

            if (PlayerData.Instance.AbilityEquiped == PlayerData.Instance.Abilities[page]) m_equipButton.interactable = false;
            else m_equipButton.interactable = true;

            m_upgradeCost.text = PlayerData.Instance.Abilities[page].Level.ToString();
            if (PlayerData.Instance.Stars < PlayerData.Instance.Abilities[page].Level) m_upgradeButton.interactable = false;

            CheckForAbilityLevel();
        }

        public void OnNextPageButtonClick()
        {
            if (m_page + 1 == PlayerData.Instance.Abilities.Count - 1) m_nextPageButton.interactable = false;
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
            PlayerData.Instance.EquipAbility(PlayerData.Instance.Abilities[m_page]);
            m_equipButton.interactable = false;
        }

        public void OnUpgradeButtonClick()
        {
            PlayerData.Instance.UpgradeAbility(m_page);
            if (PlayerData.Instance.Stars < PlayerData.Instance.Abilities[m_page].Level) m_upgradeButton.interactable = false;
            CheckForAbilityLevel();
        }

        private void CheckForAbilityLevel()
        {
            if (PlayerData.Instance.Abilities[m_page].Level == 5)
            {
                m_upgradeCost.text = "MAX";
                m_upgradeButton.interactable = false;
            }
        }
    }
}