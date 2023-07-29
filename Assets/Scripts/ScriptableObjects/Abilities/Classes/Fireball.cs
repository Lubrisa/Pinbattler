using System;
using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    [Serializable]
    [CreateAssetMenu(fileName = "Fireball", menuName = "Ability/Fireball")]
    public class Fireball : Ability
    {
        [field: SerializeField] public override string Name { get; protected set; }
        [field: SerializeField] public override Sprite Icon { get; protected set; }
        [field: SerializeField] public override string LoreDescription { get; protected set; }
        [field: SerializeField] public override string MechanicDescription { get; protected set; }
        [field: SerializeField] public override int Cooldown { get; protected set; }
        [field: SerializeField] public override int Level { get; set; }

        public override void Cast()
        {
        }
    }
}