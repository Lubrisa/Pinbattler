using Pinbattlers.Match;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapNamePointChallengeID", menuName = "Challenges/PointChallenge")]
    public class PointChallenge : BaseChallenge
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [SerializeField] private int m_scoreTarget;

        public override bool Concluded { get; set; }

        public override bool ConclusionVerification()
        {
            if (m_scoreTarget <= MatchManager.Instance.Score)
            {
                Concluded = true;
                return true;
            }
            else return false;
        }
    }
}