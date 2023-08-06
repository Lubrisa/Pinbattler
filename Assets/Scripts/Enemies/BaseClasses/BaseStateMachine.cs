using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    #region Attributes

    public abstract int MaxLife { get; protected set; }
    public abstract int CurrentLife { get; protected set; }
    public abstract int Attack { get; protected set; }
    public abstract int Defense { get; protected set; }
    public abstract float MoveSpeed { get; protected set; }

    #endregion Attributes

    public abstract BaseState CurrentState { get; protected set; }

    public abstract bool IsAttacking { get; set; }
    public abstract bool Attacked { get; set; }

    protected abstract void Start();

    protected abstract void Update();

    protected abstract void FixedUpdate();

    public abstract void EnterNewState(BaseState newState);
}