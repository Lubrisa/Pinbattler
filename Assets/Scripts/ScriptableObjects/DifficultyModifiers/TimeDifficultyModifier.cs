using Pinbattlers.Match;
using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDTimeModifier", menuName = "DifficultyModifiers/TimeDifficultyModifier")]
    public class TimeDifficultyModifier : BaseDifficultyModifier
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool IsEnabled { get; set; }

        [field: SerializeField] public override Consumable[] RewardPool { get; protected set; }

        [field: SerializeField] public override List<Consumable> Rewards { get; protected set; }

        [field: SerializeField] public override Relic RelicReward { get; protected set; }

        [field: SerializeField] public override bool Concluded { get; protected set; }

        [field: SerializeField] private float m_timeLimit;
        private float m_remainingTime;

        [field: SerializeField] private int m_pointToReach;

        public override void Effect()
        {
            m_remainingTime = m_timeLimit;
        }

        public override bool MissionVerification()
        {
            if (m_pointToReach <= MatchManager.Instance.Score)
            {
                if (RelicReward != null) GameOverMenuController.Instance.Relics.Add(RelicReward);
                Rewards = GenerateRewardPool();
                if (!Concluded) Concluded = true;
                return true;
            }
            else if (m_remainingTime > 0) m_remainingTime -= Time.deltaTime;
            else MatchManager.Instance.GameOver();

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