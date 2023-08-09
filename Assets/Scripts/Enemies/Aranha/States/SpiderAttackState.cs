using UnityEngine;

[CreateAssetMenu(fileName = "SpiderAttackState", menuName = "StateMachine/Spider/SpiderAttackState")]
public class SpiderAttackState : BaseState
{
    public override BaseStateMachine Machine { get; protected set; }

    private GameObject m_player;

    [SerializeField] private BaseState m_walkingState;

    public override void Enter(BaseStateMachine machine)
    {
        Machine = machine;

        m_player = GameObject.FindGameObjectWithTag("Player");

        Machine.IsAttacking = true;

        Machine.transform.GetComponent<Animator>().SetBool("Walking", true);
    }

    public override void Exit()
    {
        Machine.transform.GetComponent<Animator>().SetBool("Walking", false);
    }

    public override void LogicUpdate()
    {
        if (!Machine.Attacked)
        {
            Machine.transform.position = Vector2.MoveTowards(Machine.transform.position, m_player.transform.position, Machine.MoveSpeed);
        }
        else
        {
            Machine.IsAttacking = false;
            Machine.Attacked = false;

            Machine.EnterNewState(m_walkingState);
        }
    }

    public override void PhysicsUpdate()
    {
    }
}