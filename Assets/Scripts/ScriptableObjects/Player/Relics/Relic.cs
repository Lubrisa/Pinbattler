using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    public abstract class Relic : Item
    {
        public override string Name { get; protected set; }
        public override Sprite Icon { get; protected set; }
        public override string LoreDescription { get; protected set; }
        public override string MechanicDescription { get; protected set; }

        public override void Effect()
        { }
    }
}