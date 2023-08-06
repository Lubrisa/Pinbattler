using Pinbattlers.Match;
using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDTimeModifier", menuName = "Quests/DifficultyModifiers/TimeDifficultyModifier")]
    public class TimeDifficultyModifier : BaseDifficultyModifier
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool IsEnabled { get; set; }

        [field: SerializeField] public override Reward Rewards { get; protected set; }

        [field: SerializeField] public override bool Concluded { get; protected set; }

        [field: SerializeField] private float m_timeLimit;
        private float m_remainingTime;

        [field: SerializeField] private int m_pointToReach;

        [SerializeField] private GameEvent m_gameOver;

        public override void StartEffect()
        {
            m_remainingTime = m_timeLimit;
        }

        public override bool MissionVerification()
        {
            if (m_pointToReach <= ScoreManager.Score)
            {
                GenerateRewards();
                Concluded = true;
                return true;
            }
            else if (m_remainingTime > 0) m_remainingTime -= Time.deltaTime;
            else m_gameOver.Raise();

            return false;
        }
    }
}