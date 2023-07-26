using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapNamePrecisionChallengeID", menuName = "Challenges/PrecisionChallenge")]
    public class PrecisionChallenge : BaseChallenge
    {
        [field: SerializeField] public override string Description { get; protected set; }

        public override bool Concluded { get; set; }

        public override void ConclusionVerification()
        {

        }
    }
}