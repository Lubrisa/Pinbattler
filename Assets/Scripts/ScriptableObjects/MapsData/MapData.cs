using Pinbattlers.Scriptables;
using UnityEngine;

namespace Pinbattlers.Menus
{
    [CreateAssetMenu(fileName = "ID_MapNameData", menuName = "MapsData")]
    public class MapData : ScriptableObject
    {
        [field: SerializeField] public string MapName { get; private set; }
        [field: SerializeField] public string MapDescription { get; private set; }
        [field: SerializeField] public Sprite MapIllustration { get; private set; }
        [field: SerializeField] public BaseChallenge[] MapChallenges { get; private set; }
        [field: SerializeField] public BaseDifficultyModifier[] MapModifiers { get; private set; }
        [field: SerializeField] public int MapHighScore { get; set; }

        [SerializeField] private MapData[] m_mapDependency;

        public bool Unlocked()
        {
            for (int i = 0; i < m_mapDependency.Length; i++)
            {
                foreach (BaseChallenge bc in m_mapDependency[i].MapChallenges)
                {
                    if (!bc.Concluded) return false;
                }
            }

            return true;
        }

        public bool Concluded()
        {
            foreach (BaseChallenge bc in MapChallenges)
            {
                if (!bc.Concluded) return false;
            }

            return true;
        }

        public bool Cleared()
        {
            foreach (BaseDifficultyModifier bdm in MapModifiers)
            {
                if (!bdm.Concluded) return false;
            }

            return true;
        }
    }
}