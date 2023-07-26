using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    public abstract class BaseDifficultyModifier : ScriptableObject
    {
        public abstract string Description { get; protected set; }

        public abstract bool IsEnabled { get; set; }

        public abstract void Effect();

        public abstract void MissionVerification();
    }
}