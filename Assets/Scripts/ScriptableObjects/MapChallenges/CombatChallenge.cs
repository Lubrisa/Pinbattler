using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapNameCombatChallengeID", menuName = "Challenges/CombatChallenge")]
    public class CombatChallenge : BaseChallenge
    {
        [field: SerializeField] public override string Description { get; protected set; }

        public override bool Concluded { get; set; }

        public override void ConclusionVerification()
        {

        }
    }
}