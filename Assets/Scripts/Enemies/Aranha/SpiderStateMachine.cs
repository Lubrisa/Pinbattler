public class SpiderStateMachine : BaseStateMachine
{
    public override BaseState CurrentState { get; protected set; }

    public override BaseState[] States { get; protected set; }

    protected override void Start()
    {
        CurrentState.Enter();
    }

    protected override void Update()
    {
        CurrentState.LogicUpdate();
        CurrentState.CheckForStateChange();
    }

    protected override void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
    }

    public override void EnterNewState(BaseState newState)
    {
        CurrentState.Exit();
        newState.Enter();
        CurrentState = newState;
    }
}