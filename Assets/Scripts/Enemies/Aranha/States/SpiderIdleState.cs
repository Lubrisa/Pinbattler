using UnityEngine;

[CreateAssetMenu(fileName = "SpiderIdleState", menuName = "StateMachine/Spider/SpiderIdleState")]
public class SpiderIdleState : BaseState
{
    public override BaseStateMachine Machine { get; protected set; }

    [SerializeField] private float m_maxIdleTime;
    private float m_timePassed;

    [SerializeField] private BaseState m_walkingState;
    [SerializeField] private BaseState m_shootingState;

    public override void Enter(BaseStateMachine machine)
    {
        Machine = machine;
        m_timePassed = m_maxIdleTime;
    }

    public override void Exit()
    {
    }

    public override void LogicUpdate()
    {
        if (m_timePassed > 0) m_timePassed -= Time.deltaTime;
        else
        {
            int choice = new System.Random().Next(0, 2);

            if (choice == 0) Machine.EnterNewState(m_walkingState);
            else Machine.EnterNewState(m_shootingState);
        }
    }

    public override void PhysicsUpdate()
    {
    }
}