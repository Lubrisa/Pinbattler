using Pinbattlers.Match;
using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDScoreModifier", menuName = "Quests/DifficultyModifiers/ScoreDifficultyModifier")]
    public class ScoreDifficultyModifier : BaseDifficultyModifier
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool IsEnabled { get; set; }

        [field: SerializeField] public override Reward Rewards { get; protected set; }

        [field: SerializeField] public override bool Concluded { get; protected set; }

        [SerializeField] private BoolVariable m_doubleRewards;
        [SerializeField] private IntVariable m_fixedPointsMultiplier;
        [SerializeField] private int m_scoreToReach;

        public override void StartEffect()
        {
            m_doubleRewards.Value = true;
            m_fixedPointsMultiplier.Value /= 2;
        }

        public override bool MissionVerification()
        {
            if (ScoreManager.Score >= m_scoreToReach)
            {
                GenerateRewards();
                Concluded = true;
                return true;
            }
            return false;
        }
    }
}