using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class GrimoireController : MonoBehaviour
    {
        private PlayerData m_playerData;

        private TMP_Text m_abilityName;
        private Image m_abilityIllustration;
        private TMP_Text m_abilityLoreDescription;
        private TMP_Text m_abilityMechanicDescription;
        private Button m_nextPageButton;
        private Button m_previousPageButton;

        [SerializeField] private IntVariable m_page;

        [Inject]
        private void Constructor(
            PlayerData playerData,
            [Inject(Id = "AbilityName")] TextMeshProUGUI abilityName,
            [Inject(Id = "AbilityLore")] TextMeshProUGUI abilityLore,
            [Inject(Id = "AbilityMechanic")] TextMeshProUGUI abilityMechanic,
            [Inject(Id = "AbilityIcon")] Image abilityIllustration,
            [Inject(Id = "AbilityNextPage")] Button nextPageButton,
            [Inject(Id = "AbilityPreviousPage")] Button previousPageButton)
        {
            m_abilityName = abilityName;
            m_abilityLoreDescription = abilityLore;
            m_abilityMechanicDescription = abilityMechanic;
            m_abilityIllustration = abilityIllustration;
            m_nextPageButton = nextPageButton;
            m_previousPageButton = previousPageButton;
            m_playerData = playerData;
        }

        private void OnEnable() => m_page.AddListener(UpdateInfo);

        private void OnDisable() => m_page.RemoveListener(UpdateInfo);

        public void UpdateInfo(int value)
        {
            m_page.Value += value != 0 ? m_page + value : value;

            m_abilityName.text = m_playerData.Abilities[m_page].Name;
            m_abilityIllustration.sprite = m_playerData.Abilities[m_page].IconSprite.IconSprite;
            m_abilityLoreDescription.text = m_playerData.Abilities[m_page].LoreDescription;
            m_abilityMechanicDescription.text = m_playerData.Abilities[m_page].MechanicDescription;
        }

        public void OnNextPageButtonClick()
        {
            if (m_page + 1 == m_playerData.Abilities.Count - 1) m_nextPageButton.interactable = false;
            if (!m_previousPageButton.interactable) m_previousPageButton.interactable = true;
            UpdateInfo(1);
        }

        public void OnPreviousPageButtonClick()
        {
            if (m_page - 1 == 0) m_previousPageButton.interactable = false;
            if (!m_nextPageButton.interactable) m_nextPageButton.interactable = true;
            UpdateInfo(-1);
        }
    }
}