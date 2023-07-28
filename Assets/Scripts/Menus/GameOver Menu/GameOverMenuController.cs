using Pinbattlers.Player;
using Pinbattlers.Player.Resouces;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

namespace Pinbattlers.Menus
{
    public class GameOverMenuController : MonoBehaviour
    {
        [Inject]
        private PlayerData m_instance;

        public static GameOverMenuController Instance { get; private set; }

        [field: SerializeField] public List<Consumable> Consumables { get; set; }
        [field: SerializeField] public List<Relic> Relics { get; private set; }
        [field: SerializeField] public Ability Ability { get; private set; }

        [field: SerializeField] public int Score { get; private set; }
        [field: SerializeField] public int Stars { get; set; }
        [field: SerializeField] public int Essences { get; set; }

        [SerializeField] private TMP_Text m_finalScoreText;
        [SerializeField] private Transform m_content;

        [SerializeField] private BaseRewardController m_pointsReward;
        [SerializeField] private BaseRewardController m_starsReward;
        [SerializeField] private BaseRewardController m_essencesReward;
        [SerializeField] private BaseRewardController m_abilityReward;
        [SerializeField] private BaseRewardController m_relicReward;
        public int RelicIndex { get; private set; }
        [SerializeField] private BaseRewardController m_consumableReward;
        public int ConsumableIndex { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(this);
        }

        [ContextMenu("FeedInventory")]
        public void FeedPlayerInventory()
        {
            for (int i = Relics.Count - 1; i >= 0; i--)
            {
                if (m_instance.Relics.Contains(Relics[i])) Relics.Remove(Relics[i]);
            }

            Ability abilityToPass = null;

            if (Ability != null && !m_instance.Abilities.Contains(Ability)) abilityToPass = Ability;

            m_instance.UpdateInventory(Score, Stars, Essences, Consumables, Relics, abilityToPass);

            UpdateInfo();
        }

        public void UpdateInfo()
        {
            m_finalScoreText.text = "Pontuação Final:\n" + Score.ToString();

            Instantiate(m_pointsReward, m_content);
            m_pointsReward.SetInfo(this);
            Instantiate(m_starsReward, m_content);
            m_starsReward.SetInfo(this);
            Instantiate(m_essencesReward, m_content);
            m_essencesReward.SetInfo(this);

            if (Ability != null)
            {
                Instantiate(m_abilityReward, m_content);
                m_abilityReward.SetInfo(this);
            }

            foreach (Relic r in Relics)
            {
                BaseRewardController reward = Instantiate(m_relicReward, m_content);
                reward.SetInfo(this);
                RelicIndex++;
            }

            foreach (Consumable r in Consumables)
            {
                BaseRewardController reward = Instantiate(m_consumableReward, m_content);
                reward.SetInfo(this);
                ConsumableIndex++;
            }
        }
    }
}