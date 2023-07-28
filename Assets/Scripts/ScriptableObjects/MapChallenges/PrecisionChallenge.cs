using ScriptableObjectArchitecture;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapNamePrecisionChallengeID", menuName = "Challenges/PrecisionChallenge")]
    public class PrecisionChallenge : BaseChallenge
    {
        [field: SerializeField] public override string Description { get; protected set; }

        public override bool Concluded { get; set; }

        [SerializeField] private BoolVariable m_wasActivated;

        public override bool ConclusionVerification()
        {
            if (m_wasActivated)
            {
                Concluded = true;
                return true;
            }
            return false;
        }
    }
}