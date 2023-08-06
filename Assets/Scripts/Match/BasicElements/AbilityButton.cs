using Pinbattlers.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Match
{
    public class AbilityButton : MonoBehaviour
    {
        [Inject]
        private PlayerData m_playerData;

        private Button m_abilityButton;

        private float m_abilityCooldownTime;

        private void Start()
        {
            m_abilityButton = GetComponent<Button>();

            if (m_playerData.AbilityEquiped == null) m_abilityButton.interactable = false;
            else m_abilityButton.image.sprite = m_playerData.AbilityEquiped.IconSprite;

            m_abilityButton.onClick.AddListener(OnAbilitym_abilityButtonClicked);
        }

        public void OnAbilitym_abilityButtonClicked()
        {
            m_playerData.AbilityEquiped.Cast();
            m_abilityButton.interactable = false;
            StartCoroutine(nameof(AbilityCooldown));
        }

        private IEnumerator AbilityCooldown()
        {
            m_abilityCooldownTime = m_playerData.AbilityEquiped.Cooldown;

            while (m_abilityCooldownTime > 0)
            {
                m_abilityCooldownTime -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            m_abilityButton.interactable = true;
        }
    }
}