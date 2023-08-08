using UnityEngine;

[CreateAssetMenu(fileName = "WebShootState", menuName = "StateMachine/Spider/WebShootState")]
public class WebShootState : BaseState
{
    public override BaseStateMachine Machine { get; protected set; }

    private GameObject m_player;

    [SerializeField] private float m_attackDelay;
    private float m_attackProgression;
    [SerializeField] private GameObject m_web;

    [SerializeField] private BaseState m_idleState;

    public override void Enter(BaseStateMachine machine)
    {
        Machine = machine;

        m_player = GameObject.FindGameObjectWithTag("Player");
        m_attackProgression = m_attackDelay;

        Machine.transform.GetComponent<Animator>().SetTrigger("Attack");
    }

    public override void Exit()
    {
        Machine.transform.GetComponent<Animator>().SetTrigger("Idle");
    }

    public override void LogicUpdate()
    {
        if (m_attackProgression > 0) m_attackProgression -= Time.deltaTime;
        else
        {
            Instantiate(m_web, Machine.transform.position, Machine.transform.rotation, Machine.transform.parent);
            Machine.EnterNewState(m_idleState);
        }
    }

    public override void PhysicsUpdate()
    {
    }
}