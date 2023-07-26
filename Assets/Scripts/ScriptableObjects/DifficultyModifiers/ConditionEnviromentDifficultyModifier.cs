using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDConditionEnviromentModifier", menuName = "DifficultyModifiers/ConditionEnviromentDifficultyModifier")]
    public class ConditionEnviromentDifficultyModifier : BaseDifficultyModifier
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