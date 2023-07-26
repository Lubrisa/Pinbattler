using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    public abstract class Ability : ScriptableObject
    {
        public abstract string Name { get; protected set; }
        public abstract Sprite Icon { get; protected set; }
        public abstract string LoreDescription { get; protected set; }
        public abstract string MechanicDescription { get; protected set; }
        public abstract int Cooldown { get; protected set; }
        public abstract int Level { get; protected set; }

        public abstract void Cast();
    }
}