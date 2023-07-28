using Pinbattlers.Enemies;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapNameCombatChallengeID", menuName = "Challenges/CombatChallenge")]
    public class CombatChallenge : BaseChallenge
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool Concluded { get; set; }

        [SerializeField] private MonsterData m_monster;
        [SerializeField] private int m_killsNeeded;
        private int m_kills;

        private void OnEnable()
        {
            m_kills = m_monster.QuantityKilled + m_killsNeeded;
        }

        public override bool ConclusionVerification()
        {
            Debug.Log("Teste");
            if (m_kills <= m_monster.QuantityKilled)
            {
                Concluded = true;
                return true;
            }
            else return false;
        }
    }
}