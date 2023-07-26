using System;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [Serializable]
    public abstract class BaseChallenge : ScriptableObject
    {
        public abstract string Description { get; protected set; }

        public abstract bool Concluded { get; set; }

        public abstract void ConclusionVerification();
    }
}