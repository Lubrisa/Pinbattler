using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class GrimoireAbilityManager : MonoBehaviour
    {
        private PlayerData m_playerData;

        private Transform m_levelStars;
        private TMP_Text m_upgradeCost;
        private Button m_upgradeButton;
        private Button m_equipButton;

        [SerializeField] private IntVariable m_page;

        [SerializeField] private GameEvent m_updateStars;

        [Inject]
        private void Constructor(
                PlayerData playerData,
                [Inject(Id = "AbilityUpgradeCost")] TextMeshProUGUI upgradeCost,
                RectTransform levelStars,
                [Inject(Id = "AbilityUpgrade")] Button upgradeButton,
                [Inject(Id = "AbilityEquip")] Button equipButton)
        {
            m_upgradeCost = upgradeCost;
            m_levelStars = levelStars;
            m_upgradeButton = upgradeButton;
            m_equipButton = equipButton;
            m_playerData = playerData;
        }

        private void OnEnable() => m_page.AddListener(UpdateInfo);

        private void OnDisable() => m_page.RemoveListener(UpdateInfo);

        public void UpdateInfo(int value)
        {
            m_page.Value = value != 0 ? m_page + value : value;

            // Setting the Ability level.
            for (int i = 0; i < m_levelStars.childCount; i++)
            {
                if (i + 1 <= m_playerData.Abilities[m_page].Level) m_levelStars.GetChild(i).gameObject.SetActive(true);
                else m_levelStars.GetChild(i).gameObject.SetActive(false);
            }

            // Setting equip disponibility.
            if (m_playerData.AbilityEquiped == m_playerData.Abilities[m_page]) m_equipButton.interactable = false;
            else m_equipButton.interactable = true;

            // Setting upgrade disponibility.
            if (m_playerData.Stars < m_playerData.Abilities[m_page].Level || m_playerData.Abilities[m_page].Level == 5)
            {
                m_upgradeButton.interactable = false;
                m_upgradeCost.text = m_playerData.Abilities[m_page].Level == 5 ? "MAX" : m_playerData.Abilities[m_page].Level.ToString();
            }
        }

        public void EquipAbility()
        {
            m_playerData.EquipAbility(m_playerData.Abilities[m_page]);
            m_equipButton.interactable = false;
        }

        public void UpgradeAbility()
        {
            m_playerData.UpgradeAbility(m_page);
            if (m_playerData.Stars < m_playerData.Abilities[m_page].Level || m_playerData.Abilities[m_page].Level == 5)
            {
                m_upgradeButton.interactable = false;
                m_upgradeCost.text = m_playerData.Abilities[m_page].Level == 5 ? "MAX" : m_playerData.Abilities[m_page].Level.ToString();
            }

            m_updateStars.Raise();
        }
    }
}