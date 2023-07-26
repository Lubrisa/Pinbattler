using System;
using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    [Serializable]
    [CreateAssetMenu(fileName = "Snowball", menuName = "Ability/Snowball")]
    public class Snowball : Ability
    {
        [field: SerializeField] public override string Name { get; protected set; }
        [field: SerializeField] public override Sprite Icon { get; protected set; }
        [field: SerializeField] public override string LoreDescription { get; protected set; }
        [field: SerializeField] public override string MechanicDescription { get; protected set; }
        [field: SerializeField] public override int Cooldown { get; protected set; }
        [field: SerializeField] public override int Level { get; protected set; }

        public override void Cast()
        {
        }
    }
}