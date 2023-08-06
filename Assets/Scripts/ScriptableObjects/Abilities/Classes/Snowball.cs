using System;
using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    [Serializable]
    [CreateAssetMenu(fileName = "Snowball", menuName = "Collectible/Ability/Snowball")]
    public class Snowball : Ability
    {
        [field: SerializeField] public override string Name { get; protected set; }
        [field: SerializeField] public override Sprite IconSprite { get; protected set; }
        [field: SerializeField] public override string LoreDescription { get; protected set; }
        [field: SerializeField] public override string MechanicDescription { get; protected set; }
        [field: SerializeField] public override int Cooldown { get; protected set; }
        [field: SerializeField] public override int Level { get; set; }

        public override void Cast()
        {
        }
    }
}