using System;
using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    [Serializable]
    [CreateAssetMenu(fileName = "LifePotion", menuName = "Collectible/Consumable/LifePotion")]
    public class LifePotion : Consumable
    {
        [field: SerializeField] public override Sprite IconSprite { get; protected set; }
        [field: SerializeField] public override string LoreDescription { get; protected set; }
        [field: SerializeField] public override string MechanicDescription { get; protected set; }
        [field: SerializeField] public override string Name { get; protected set; }
        [field: SerializeField] public override int Quantity { get; set; }
        [field: SerializeField] public override Rarity ItemRarity { get; protected set; }

        public override void Effect()
        {
        }
    }
}