using Pinbattlers.Enemies;
using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDChampionModifier", menuName = "DifficultyModifiers/ChampionDifficultyModifier")]
    public class ChampionDifficultyModifier : BaseDifficultyModifier
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool IsEnabled { get; set; }

        [field: SerializeField] public override Consumable[] RewardPool { get; protected set; }

        [field: SerializeField] public override List<Consumable> Rewards { get; protected set; }

        [field: SerializeField] public override Relic RelicReward { get; protected set; }

        [field: SerializeField] private MonsterData m_monsterData;
        [SerializeField] private int m_killsNeeded;
        private int m_matchStartKills;

        public override void Effect()
        {
            m_monsterData.IsChampion = true;
            m_matchStartKills = m_monsterData.QuantityKilled;
        }

        public override bool MissionVerification()
        {
            Debug.Log(m_killsNeeded + m_matchStartKills - m_monsterData.QuantityKilled);
            if (m_killsNeeded + m_matchStartKills <= m_monsterData.QuantityKilled)
            {
                if (RelicReward != null) GameOverMenuController.Instance.Relics.Add(RelicReward);
                Rewards = GenerateRewardPool();
                return true;
            }
            else return false;
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