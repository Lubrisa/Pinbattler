using Pinbattlers.Match;
using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDScoreModifier", menuName = "DifficultyModifiers/ScoreDifficultyModifier")]
    public class ScoreDifficultyModifier : BaseDifficultyModifier
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool IsEnabled { get; set; }

        [field: SerializeField] public override Consumable[] RewardPool { get; protected set; }
        [field: SerializeField] public override List<Consumable> Rewards { get; protected set; }

        [field: SerializeField] public override Relic RelicReward { get; protected set; }

        [SerializeField] private IntVariable m_fixedPointsMultiplier;
        [SerializeField] private int m_scoreToReach;

        public override void Effect()
        {
            m_fixedPointsMultiplier.Value /= 2;
        }

        public override bool MissionVerification()
        {
            if (MatchManager.Instance.Score >= m_scoreToReach)
            {
                if (RelicReward != null) GameOverMenuController.Instance.Relics.Add(RelicReward);
                Rewards = GenerateRewardPool();
                return true;
            }
            return false;
        }

        public List<Consumable> GenerateRewardPool()
        {
            List<Consumable> pool = new List<Consumable>();

            for (int i = 0; i < Rewards.Count; i++)
            {
                int itemIndex = new System.Random().Next(0, RewardPool.Length);

                if (pool.Contains(RewardPool[itemIndex])) i--;
                else pool.Add(RewardPool[itemIndex]);
            }

            return pool;
        }
    }
}