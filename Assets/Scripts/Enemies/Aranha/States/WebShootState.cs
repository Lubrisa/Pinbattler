using UnityEngine;

[CreateAssetMenu(fileName = "WebShootState", menuName = "StateMachine/Spider/WebShootState")]
public class WebShootState : BaseState
{
    public override BaseStateMachine Machine { get; protected set; }

    private GameObject m_player;

    [SerializeField] private GameObject m_web;

    [SerializeField] private BaseState m_idleState;

    public override void Enter(BaseStateMachine machine)
    {
        Machine = machine;

        m_player = GameObject.FindGameObjectWithTag("Player");

        Machine.transform.GetComponent<Animator>().SetBool("Attack", true);
    }

    public override void Exit()
    {
        Machine.transform.GetComponent<Animator>().SetBool("Attack", false);
    }

    public override void LogicUpdate()
    {
        Instantiate(m_web, Machine.transform.position, Machine.transform.rotation, Machine.transform.parent);
        Machine.EnterNewState(m_idleState);
    }

    public override void PhysicsUpdate()
    {
    }
}