using System;
using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    [Serializable]
    [CreateAssetMenu(fileName = "AbilityRecover", menuName = "Consumable/AbilityRecover")]
    public class AbilityRecover : Consumable
    {
        [field: SerializeField] public override Sprite Icon { get; protected set; }
        [field: SerializeField] public override string LoreDescription { get; protected set; }
        [field: SerializeField] public override string MechanicDescription { get; protected set; }
        [field: SerializeField] public override string Name { get; protected set; }
        [field: SerializeField] public override int Quantity { get; protected set; }
        [field: SerializeField] public override Rarity ItemRarity { get; protected set; }

        public override void Effect()
        {
        }
    }
}