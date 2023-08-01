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

        [field: SerializeField] public override Reward Rewards { get; protected set; }

        [field: SerializeField] public override bool Concluded { get; protected set; }

        [SerializeField] private BaseMatchEvent m_event;

        [SerializeField] private BoolVariable m_wasActive;

        public override void StartEffect()
        {
        }

        public override bool MissionVerification()
        {
            if (m_wasActive)
            {
                GenerateRewards();
                Concluded = true;
                return true;
            }
            return false;
        }
    }
}