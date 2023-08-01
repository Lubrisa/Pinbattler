using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class GrimoireController : MonoBehaviour
    {
        [Inject]
        private PlayerData m_instance;

        private TMP_Text m_abilityName;
        private Image m_abilityIllustration;
        private TMP_Text m_abilityLoreDescription;
        private TMP_Text m_abilityMechanicDescription;
        private Transform m_levelStars;
        private TMP_Text m_upgradeCost;
        private Button m_nextPageButton;
        private Button m_previousPageButton;
        private Button m_equipButton;
        private Button m_upgradeButton;

        private int m_page;

        [Inject]
        private void Constructor(
            [Inject(Id = "AbilityName")] TextMeshProUGUI abilityName,
            [Inject(Id = "AbilityLore")] TextMeshProUGUI abilityLore,
            [Inject(Id = "AbilityMechanic")] TextMeshProUGUI abilityMechanic,
            [Inject(Id = "AbilityIcon")] Image abilityIllustration,
            [Inject(Id = "AbilityUpgradeCost")] TextMeshProUGUI upgradeCost,
            RectTransform levelStars,
            [Inject(Id = "AbilityNextPage")] Button nextPageButton,
            [Inject(Id = "AbilityPreviousPage")] Button previousPageButton,
            [Inject(Id = "AbilityEquip")] Button equipButton,
            [Inject(Id = "AbilityUpgrade")] Button upgradeButton)
        {
            m_abilityName = abilityName;
            m_abilityLoreDescription = abilityLore;
            m_abilityMechanicDescription = abilityMechanic;
            m_abilityIllustration = abilityIllustration;
            m_upgradeCost = upgradeCost;
            m_levelStars = levelStars;
            m_nextPageButton = nextPageButton;
            m_previousPageButton = previousPageButton;
            m_equipButton = equipButton;
            m_upgradeButton = upgradeButton;

            m_page = 0;
        }

        public void UpdateInfo(int page)
        {
            m_page = page;

            m_abilityName.text = m_instance.Abilities[m_page].Name;
            m_abilityIllustration.sprite = m_instance.Abilities[m_page].IconSprite.IconSprite;
            m_abilityLoreDescription.text = m_instance.Abilities[m_page].LoreDescription;
            m_abilityMechanicDescription.text = m_instance.Abilities[m_page].MechanicDescription;

            for (int i = 0; i < m_levelStars.childCount; i++)
            {
                if (i + 1 <= m_instance.Abilities[m_page].Level) m_levelStars.GetChild(i).gameObject.SetActive(true);
                else m_levelStars.GetChild(i).gameObject.SetActive(false);
            }

            if (m_instance.AbilityEquiped == m_instance.Abilities[page]) m_equipButton.interactable = false;
            else m_equipButton.interactable = true;

            m_upgradeCost.text = m_instance.Abilities[page].Level.ToString();
            if (m_instance.Stars < m_instance.Abilities[page].Level) m_upgradeButton.interactable = false;

            CheckAbilityLevel();
        }

        public void OnNextPageButtonClick()
        {
            if (m_page + 1 == m_instance.Abilities.Count - 1) m_nextPageButton.interactable = false;
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
            m_instance.EquipAbility(m_instance.Abilities[m_page]);
            m_equipButton.interactable = false;
        }

        public void OnUpgradeButtonClick()
        {
            m_instance.UpgradeAbility(m_page);
            if (m_instance.Stars < m_instance.Abilities[m_page].Level) m_upgradeButton.interactable = false;
            CheckAbilityLevel();
        }

        private void CheckAbilityLevel()
        {
            if (m_instance.Abilities[m_page].Level == 5)
            {
                m_upgradeCost.text = "MAX";
                m_upgradeButton.interactable = false;
            }
        }
    }
}