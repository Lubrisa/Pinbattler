using System;
using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    [Serializable]
    public abstract class Ability : ScriptableObject
    {
        public abstract string Name { get; protected set; }
        public abstract Sprite IconSprite { get; protected set; }
        public abstract string LoreDescription { get; protected set; }
        public abstract string MechanicDescription { get; protected set; }
        public abstract int Cooldown { get; protected set; }
        public abstract int Level { get; set; }

        public abstract void Cast();
    }
}