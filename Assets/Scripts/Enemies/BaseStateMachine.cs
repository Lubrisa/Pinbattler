using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    public abstract BaseState CurrentState { get; protected set; }

    public abstract BaseState[] States { get; protected set; }

    protected abstract void Start();

    protected abstract void Update();

    protected abstract void FixedUpdate();

    public abstract void EnterNewState(BaseState newState);
}