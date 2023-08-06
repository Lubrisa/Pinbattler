using UnityEngine;

public abstract class BaseState : ScriptableObject
{
    public abstract BaseStateMachine Machine { get; protected set; }

    public abstract void Enter(BaseStateMachine machine);

    public abstract void LogicUpdate();

    public abstract void PhysicsUpdate();

    public abstract void Exit();
}