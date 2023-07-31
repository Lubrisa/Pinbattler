using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    public abstract class Relic : Item
    {
        public abstract override string Name { get; protected set; }
        public abstract override Icon IconSprite { get; protected set; }
        public abstract override string LoreDescription { get; protected set; }
        public abstract override string MechanicDescription { get; protected set; }
        public abstract override Rarity ItemRarity { get; protected set; }

        public abstract override void Effect();
    }
}