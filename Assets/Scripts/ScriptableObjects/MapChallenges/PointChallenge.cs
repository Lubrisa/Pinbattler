using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapNamePointChallengeID", menuName = "Challenges/PointChallenge")]
    public class PointChallenge : BaseChallenge
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public int ScoreTarget { get; private set; }
        public override bool Concluded { get; set; }

        public override void ConclusionVerification()
        {

        }
    }
}