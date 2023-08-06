using System;
using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    [Serializable]
    [CreateAssetMenu(fileName = "IronHull", menuName = "Collectible/Relic/IronHull")]
    public class IronHull : Relic
    {
        [field: SerializeField] public override string Name { get; protected set; }
        [field: SerializeField] public override Sprite IconSprite { get; protected set; }
        [field: SerializeField] public override string LoreDescription { get; protected set; }
        [field: SerializeField] public override string MechanicDescription { get; protected set; }

        [field: SerializeField] public override Rarity ItemRarity { get; protected set; }

        public override void Effect()
        { }
    }
}