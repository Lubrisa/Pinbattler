using Pinbattlers.Player;
using UnityEngine;

public abstract class Condition : ScriptableObject
{
    public abstract float MaxDuration { get; protected set; }

    public abstract float RemainingTime { get; protected set; }

    public abstract int StackFactor { get; protected set; }

    public abstract void OnEnter(PlayerController playerController);

    public abstract void UpdateCondition();

    public abstract void OnStack();

    public abstract void OnExit();
}