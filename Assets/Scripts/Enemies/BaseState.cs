using UnityEngine;

public abstract class BaseState : ScriptableObject
{
    public abstract BaseStateMachine Machine { get; protected set; }

    public abstract void Enter();

    public abstract void LogicUpdate();

    public abstract void PhysicsUpdate();

    public abstract void Exit();

    public abstract void CheckForStateChange();
}