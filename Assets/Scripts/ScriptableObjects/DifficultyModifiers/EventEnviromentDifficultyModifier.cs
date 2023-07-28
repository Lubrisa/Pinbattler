using Pinbattlers.Match;
using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDEventEnviromentModifier", menuName = "DifficultyModifiers/EventEnviromentDifficultyModifier")]
    public class EventEnviromentDifficultyModifier : BaseDifficultyModifier
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool IsEnabled { get; set; }

        [field: SerializeField] public override Consumable[] RewardPool { get; protected set; }

        [field: SerializeField] public override List<Consumable> Rewards { get; protected set; }

        [field: SerializeField] public override Relic RelicReward { get; protected set; }

        [SerializeField] private BaseMatchEvent m_event;

        [SerializeField] private BoolVariable m_wasActive;

        public override void Effect()
        {
            MatchManager.Instance.ModifierEvent = m_event;
        }

        public override bool MissionVerification()
        {
            if (m_wasActive)
            {
                if (RelicReward != null) GameOverMenuController.Instance.Relics.Add(RelicReward);
                Rewards = GenerateRewardPool();
                m_wasActive.Value = false;
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