using Pinbattlers.Match;
using Pinbattlers.Player;
using Pinbattlers.Player.Resouces;
using Pinbattlers.Scriptables;
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

        [SerializeField] private MapsData m_mapUnlockData;

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

            if (Ability != null && m_mapUnlockData.Cleared()) abilityToPass = Ability;

            m_instance.UpdateInventory(Score, Stars, Essences, Consumables, Relics, abilityToPass);

            UpdateInfo();
        }

        public void UpdateInfo()
        {
            m_finalScoreText.text = "Pontuação Final:\n" + Score.ToString();

            BaseRewardController reward;

            reward = Instantiate(m_pointsReward, m_content);
            reward.SetInfo(this);
            reward = Instantiate(m_starsReward, m_content);
            reward.SetInfo(this);
            reward = Instantiate(m_essencesReward, m_content);
            reward.SetInfo(this);

            if (Ability != null)
            {
                reward = Instantiate(m_abilityReward, m_content);
                reward.SetInfo(this);
            }

            foreach (Relic r in Relics)
            {
                reward = Instantiate(m_relicReward, m_content);
                reward.SetInfo(this);
                RelicIndex++;
            }

            foreach (Consumable r in Consumables)
            {
                reward = Instantiate(m_consumableReward, m_content);
                reward.SetInfo(this);
                ConsumableIndex++;
            }
        }
    }
}