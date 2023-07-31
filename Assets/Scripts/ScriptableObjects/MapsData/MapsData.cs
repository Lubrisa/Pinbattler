using Pinbattlers.Scriptables;
using System;
using UnityEngine;

namespace Pinbattlers.Menus
{
    [CreateAssetMenu(fileName = "ID_MapNameData", menuName = "MapsData")]
    [Serializable]
    public class MapsData : ScriptableObject
    {
        [field: SerializeField] public string MapName { get; private set; }
        [field: SerializeField] public string MapDescription { get; private set; }
        [field: SerializeField] public Sprite MapIllustration { get; private set; }
        [field: SerializeField] public BaseChallenge[] MapChallenges { get; private set; }

        [field: SerializeField] public BaseDifficultyModifier[] MapModifiers { get; private set; }

        [field: SerializeField] public int MapHighScore { get; set; }

        [SerializeField] private MapsData[] m_mapDependency;

        [field: SerializeField] public bool Unlocked { get; private set; }

        [field: SerializeField] public bool Concluded { get; private set; }

        public bool CheckUnlock()
        {
            for (int i = 0; i < m_mapDependency.Length; i++)
            {
                bool areChallengesConcluded = true;

                foreach (BaseChallenge bc in m_mapDependency[i].MapChallenges)
                {
                    if (!bc.Concluded)
                    {
                        areChallengesConcluded = false;
                        break;
                    }
                }

                if (areChallengesConcluded) Unlocked = true;
            }

            return Unlocked;
        }

        public bool CheckConclusion()
        {
            bool wasConcluded = true;

            for (int i = 0; i < MapModifiers.Length; i++)
            {
                if (!MapModifiers[i].Concluded)
                {
                    wasConcluded = false;
                    break;
                }
            }

            Concluded = wasConcluded;

            return Concluded;
        }
    }
}