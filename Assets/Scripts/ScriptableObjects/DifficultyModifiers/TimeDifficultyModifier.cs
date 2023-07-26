using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDTimeModifier", menuName = "DifficultyModifiers/TimeDifficultyModifier")]
    public class TimeDifficultyModifier : BaseDifficultyModifier
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