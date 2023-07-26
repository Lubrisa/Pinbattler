using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDScoreModifier", menuName = "DifficultyModifiers/ScoreDifficultyModifier")]
    public class ScoreDifficultyModifier : BaseDifficultyModifier
    {
        [field: SerializeField] public override string Description { get; protected set; }

        [field: SerializeField] public override bool IsEnabled { get; set; }

        public override void Effect()
        {

        }

        public override void MissionVerification()
        {

        }
    }
}