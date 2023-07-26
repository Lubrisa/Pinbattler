using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDEventEnviromentModifier", menuName = "DifficultyModifiers/EventEnviromentDifficultyModifier")]
    public class EventEnviromentDifficultyModifier : BaseDifficultyModifier
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