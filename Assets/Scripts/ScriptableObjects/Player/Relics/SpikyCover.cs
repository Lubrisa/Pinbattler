using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    [CreateAssetMenu(fileName = "SpikyCover", menuName = "Relic/SpikyCover")]
    public class SpikyCover : Relic
    {
        public override string Name { get; protected set; }
        public override Sprite Icon { get; protected set; }
        public override string LoreDescription { get; protected set; }
        public override string MechanicDescription { get; protected set; }

        public override void Effect()
        { }
    }
}