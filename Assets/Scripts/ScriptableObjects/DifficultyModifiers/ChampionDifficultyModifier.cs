using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [CreateAssetMenu(fileName = "MapIDChampionModifier", menuName = "DifficultyModifiers/ChampionDifficultyModifier")]
    public class ChampionDifficultyModifier : BaseDifficultyModifier
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