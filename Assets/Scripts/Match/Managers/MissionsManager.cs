using Pinbattlers.Menus;
using Pinbattlers.Scriptables;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pinbattlers.Match
{
    public class MissionsManager : MonoBehaviour
    {
        [Inject]
        private MapData m_mapData;

        private List<BaseChallenge> m_challenges = new List<BaseChallenge>();
        private List<BaseDifficultyModifier> m_modifiers = new List<BaseDifficultyModifier>();

        private void Start()
        {
            if (m_mapData.MapChallenges != null)
            {
                foreach (BaseChallenge c in m_mapData.MapChallenges)
                {
                    if (!c.Concluded) m_challenges.Add(c);
                }
            }

            if (m_mapData.MapChallenges != null)
            {
                foreach (BaseDifficultyModifier m in m_mapData.MapModifiers)
                {
                    if (m.IsEnabled) m_modifiers.Add(m);
                    m.StartEffect();
                }
            }
        }

        private void Update()
        {
            for (int i = 0; m_challenges != null && i < m_challenges.Count; i++)
            {
                if (m_challenges[i].ConclusionVerification()) m_challenges.Remove(m_challenges[i]);
            }

            for (int i = 0; m_modifiers != null && i < m_modifiers.Count; i++)
            {
                if (m_modifiers[i].MissionVerification()) m_modifiers.Remove(m_modifiers[i]);
            }
        }
    }
}