using Pinbattlers.Player.Resouces;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    public abstract class BaseDifficultyModifier : ScriptableObject
    {
        public abstract string Description { get; protected set; }

        public abstract bool IsEnabled { get; set; }

        public abstract Consumable[] RewardPool { get; protected set; }

        public abstract List<Consumable> Rewards { get; protected set; }

        public abstract Relic RelicReward { get; protected set; }

        public abstract void Effect();

        public abstract bool MissionVerification();
    }
}