using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    public abstract class Consumable : Item
    {
        public abstract override Sprite Icon { get; protected set; }
        public abstract override string LoreDescription { get; protected set; }
        public abstract override string MechanicDescription { get; protected set; }
        public abstract override string Name { get; protected set; }

        public abstract override void Effect();
    }
}