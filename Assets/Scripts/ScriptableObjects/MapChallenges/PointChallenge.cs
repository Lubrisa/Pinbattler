using Pinbattlers.Match;
using Pinbattlers.Menus;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapNamePointChallengeID", menuName = "Quests/Challenges/PointChallenge")]
    public class PointChallenge : BaseChallenge
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [SerializeField] private int m_scoreTarget;

        [field: SerializeField] public override bool Concluded { get; set; }

        public override bool ConclusionVerification()
        {
            if (m_scoreTarget <= ScoreManager.Score)
            {
                GameOverMenuController.Instance.Stars += 1;
                Concluded = true;
                return true;
            }
            else
                return false;
        }
    }
}