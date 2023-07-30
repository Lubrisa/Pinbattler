using Pinbattlers.Scriptables;
using UnityEngine;

namespace Pinbattlers.Menus
{
    [CreateAssetMenu(fileName = "ID_MapNameData", menuName = "MapsData")]
    public class MapsData : ScriptableObject
    {
        [field: SerializeField] public string MapName { get; private set; }
        [field: SerializeField] public string MapDescription { get; private set; }
        [field: SerializeField] public Sprite MapIllustration { get; private set; }

        [field: SerializeField] public BaseChallenge[] MapChallenges { get; private set; }

        [field: SerializeField] public BaseDifficultyModifier[] MapModifiers { get; private set; }

        [field: SerializeField] public int MapHighScore { get; set; }

        [field: SerializeField] public bool[] Unlocked { get; set; }

        [field: SerializeField] public bool Concluded { get; set; }
    }
}