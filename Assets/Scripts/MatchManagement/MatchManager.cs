using Pinbattlers.Menus;
using Pinbattlers.Scriptables;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Match
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] private MapsData m_mapData;

        [SerializeField] private List<BaseChallenge> m_challenges;
        [SerializeField] private List<BaseDifficultyModifier> m_modifiers;

        private BaseMatchEvent m_event;
        private BaseMatchEvent m_modifierEvent;

        [field: SerializeField] public int Score { get; private set; }

        private void Start()
        {
            foreach (BaseChallenge c in m_mapData.MapChallenges)
            {
                if (!c.Concluded) m_challenges.Add(c);
            }

            foreach (BaseDifficultyModifier m in m_mapData.MapModifiers)
            {
                if (m.IsEnabled) m_modifiers.Add(m);
                m.Effect();
            }
        }

        private void Update()
        {
            foreach (BaseChallenge bc in m_challenges)
            {
                bc.ConclusionVerification();
            }

            foreach (BaseDifficultyModifier bdm in m_modifiers)
            {
                bdm.MissionVerification();
            }

            m_event?.Effect();
        }

        public void SwitchMatchEvent(BaseMatchEvent matchEvent)
        {
            m_event?.Exit();
            matchEvent.Enter();
            m_event = matchEvent;
        }

        public void EndMatch()
        {
        }
    }
}