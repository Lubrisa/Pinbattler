using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    public abstract class Consumable : Item
    {
        public abstract override Sprite IconSprite { get; protected set; }
        public abstract override string LoreDescription { get; protected set; }
        public abstract override string MechanicDescription { get; protected set; }
        public abstract override string Name { get; protected set; }
        public abstract int Quantity { get; set; }
        public abstract override Rarity ItemRarity { get; protected set; }

        public abstract override void Effect();
    }
}