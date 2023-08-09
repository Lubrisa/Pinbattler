using UnityEngine;

[CreateAssetMenu(fileName = "WalkingState", menuName = "StateMachine/Universal/WalkingState")]
public class WalkingState : BaseState
{
    public override BaseStateMachine Machine { get; protected set; }

    [SerializeField] private Vector2[] m_walkPositions;
    private int m_positionToWalk;

    [SerializeField] private BaseState m_idleState;

    public override void Enter(BaseStateMachine machine)
    {
        Machine = machine;

        RaycastHit2D hit;
        for (int i = 0; i < 10; i++)
        {
            m_positionToWalk = new System.Random().Next(0, m_walkPositions.Length);

            hit = Physics2D.Raycast(Machine.transform.position, m_walkPositions[m_positionToWalk], LayerMask.GetMask("Obstacle"));

            if (hit.collider == null && Vector2.Distance(Machine.transform.position, m_walkPositions[m_positionToWalk]) > 1f) break;
        }

        Machine.transform.GetComponent<Animator>().SetBool("Walking", true);
    }

    public override void Exit()
    {
        Machine.transform.GetComponent<Animator>().SetBool("Walking", false);
    }

    public override void LogicUpdate()
    {
        Machine.transform.position = Vector2.MoveTowards(Machine.transform.position, m_walkPositions[m_positionToWalk], Machine.MoveSpeed);

        if (Vector2.Distance(Machine.transform.position, m_walkPositions[m_positionToWalk]) < 0.5f)
        {
            Machine.EnterNewState(m_idleState);
        }
    }

    public override void PhysicsUpdate()
    {
    }
}