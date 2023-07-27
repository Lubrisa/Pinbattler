using System;
using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    public abstract class Consumable : Item
    {
        public abstract override Sprite Icon { get; protected set; }
        public abstract override string LoreDescription { get; protected set; }
        public abstract override string MechanicDescription { get; protected set; }
        public abstract override string Name { get; protected set; }
        public abstract int Quantity { get; protected set; }
        public abstract Rarity ItemRarity { get; protected set; }

        public abstract override void Effect();

        [Serializable]
        public class Rarity
        {
            public enum RarityTypes
            {
                Commom,
                Uncommom,
                Rare,
                Legendary
            }

            [field: SerializeField] public RarityTypes RarityType { get; private set; }

            public string RarityName
            {
                get
                {
                    if (RarityType == RarityTypes.Commom) return "<color=white>Comum</color>";
                    else if (RarityType == RarityTypes.Uncommom) return "<color=green>Incomum</color>";
                    else if (RarityType == RarityTypes.Rare) return "<color=blue>Raro</color>";
                    else return "<color=orange>Lendário</color>";
                }
            }
        }
    }
}