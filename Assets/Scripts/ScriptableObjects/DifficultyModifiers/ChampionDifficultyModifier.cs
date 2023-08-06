using Pinbattlers.Enemies;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDChampionModifier", menuName = "Quests/DifficultyModifiers/ChampionDifficultyModifier")]
    public class ChampionDifficultyModifier : BaseDifficultyModifier
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool IsEnabled { get; set; }

        [field: SerializeField] public override Reward Rewards { get; protected set; }

        [field: SerializeField] public override bool Concluded { get; protected set; }

        [SerializeField] private MonsterData m_monsterData;
        [SerializeField] private GameObject m_championPrefab;
        [SerializeField] private GameObjectGameEvent m_changeMonsterSpawn;
        [SerializeField] private int m_killsNeeded;
        private int m_kills;

        public override void StartEffect()
        {
            m_changeMonsterSpawn.Raise();
            m_kills = m_monsterData.QuantityKilled + m_killsNeeded;
        }

        public override bool MissionVerification()
        {
            Debug.Log(m_kills);
            if (m_kills <= m_monsterData.QuantityKilled)
            {
                GenerateRewards();
                Concluded = true;
                return true;
            }
            else return false;
        }
    }
}