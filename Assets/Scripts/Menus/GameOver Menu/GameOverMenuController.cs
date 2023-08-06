using Pinbattlers.Player;
using Pinbattlers.Player.Resouces;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Pinbattlers.Menus
{
    public class GameOverMenuController : MonoBehaviour
    {
        public static GameOverMenuController Instance { get; private set; }

        #region PlayerAndMapData

        [Inject]
        private PlayerData m_playerData;

        [Inject]
        private MapsData m_mapData;

        #endregion PlayerAndMapData

        #region Rewards

        [field: SerializeField] public int Score { get; set; }
        [field: SerializeField] public int Stars { get; set; }
        [field: SerializeField] public int Essences { get; set; }
        [field: SerializeField] public List<Consumable> Consumables { get; set; }
        [field: SerializeField] public List<Relic> Relics { get; set; }
        [field: SerializeField] public Ability Ability { get; private set; }

        #endregion Rewards

        #region RewardControllers

        [SerializeField] private BaseRewardController m_pointsReward;
        [SerializeField] private BaseRewardController m_starsReward;
        [SerializeField] private BaseRewardController m_essencesReward;
        [SerializeField] private BaseRewardController m_abilityReward;
        public int RelicIndex { get; private set; }
        [SerializeField] private BaseRewardController m_relicReward;
        public int ConsumableIndex { get; private set; }
        [SerializeField] private BaseRewardController m_consumableReward;

        #endregion RewardControllers

        [SerializeField] private IntVariable m_fixedScoreModifier;
        [SerializeField] private BoolVariable m_doubleRewards;

        [SerializeField] private TMP_Text m_finalScoreText;
        [SerializeField] private Transform m_content;

        [Inject]
        private void Constructor([Inject(Id = "FinalScore")] TextMeshProUGUI finalScoreText, [Inject(Id = "GameOverContent")] RectTransform content)
        {
            m_finalScoreText = finalScoreText;
            m_content = content;
        }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(this);
        }

        public void UpdateInfo()
        {
            if (m_doubleRewards.Value) DoubleRewards();

            m_finalScoreText.text = "Pontuação:\n" + Score.ToString() + " x " + m_fixedScoreModifier.Value.ToString() +
                "\nPontuação Final: " + (Score * m_fixedScoreModifier.Value).ToString();

            Score *= m_fixedScoreModifier.Value;

            BaseRewardController reward;
            if (Score > 0)
            {
                reward = Instantiate(m_pointsReward, m_content);
                reward.SetInfo(this);
            }

            if (Stars > 0)
            {
                reward = Instantiate(m_starsReward, m_content);
                reward.SetInfo(this);
            }

            if (Essences > 0)
            {
                reward = Instantiate(m_essencesReward, m_content);
                reward.SetInfo(this);
            }

            if (Ability != null && m_mapData.Cleared() && !m_playerData.Abilities.Contains(Ability))
            {
                reward = Instantiate(m_abilityReward, m_content);
                reward.SetInfo(this);
            }
            else Ability = null;

            if (Relics != null)
            {
                foreach (Relic r in Relics)
                {
                    if (!m_playerData.Relics.Contains(r))
                    {
                        reward = Instantiate(m_relicReward, m_content);
                        reward.SetInfo(this);
                        RelicIndex++;
                    }
                    else Relics.Remove(r);
                }
            }

            if (Consumables != null)
            {
                foreach (Consumable r in Consumables)
                {
                    reward = Instantiate(m_consumableReward, m_content);
                    reward.SetInfo(this);
                    ConsumableIndex++;
                }
            }

            if (Score > m_mapData.MapHighScore) m_mapData.MapHighScore = Score;

            if (m_doubleRewards.Value) m_doubleRewards.Value = false;

            FeedPlayerInventory();
        }

        private void DoubleRewards()
        {
            Essences *= 2;

            foreach (Consumable c in Consumables)
            {
                c.Quantity *= 2;
            }
        }

        [ContextMenu("FeedInventory")]
        public void FeedPlayerInventory() => m_playerData.UpdateInventory(Score, Stars, Essences, Consumables, Relics, Ability);
    }
}