using Pinbattlers.Menus;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapNamePrecisionChallengeID", menuName = "Quests/Challenges/PrecisionChallenge")]
    public class PrecisionChallenge : BaseChallenge
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool Concluded { get; set; }

        [SerializeField] private BoolVariable m_wasActivated;

        public override bool ConclusionVerification()
        {
            Debug.Log("Obstáculo que precisa ativar: " + m_wasActivated.name);
            if (m_wasActivated)
            {
                GameOverMenuController.Instance.Stars += 1;
                Concluded = true;
                return true;
            }
            return false;
        }
    }
}