using UnityEngine;

namespace Pinbattlers.Match
{
    public abstract class BaseMatchEvent : MonoBehaviour
    {
        public abstract void Enter();

        public abstract void Effect();

        public abstract void Exit();
    }
}