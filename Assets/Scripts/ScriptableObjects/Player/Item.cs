using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    public abstract class Item : ScriptableObject
    {
        public abstract Sprite Icon { get; protected set; }
        public abstract string LoreDescription { get; protected set; }
        public abstract string MechanicDescription { get; protected set; }
        public abstract string Name { get; protected set; }

        public abstract void Effect();
    }
}