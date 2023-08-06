using Pinbattlers.Enemies;
using UnityEngine;
using UnityEngine.UI;

public class TatuStateMachine : BaseStateMachine, IEnemy
{
    [SerializeField] private MonsterData m_monsterData;

    public override int MaxLife { get; protected set; }
    public override int CurrentLife { get; protected set; }
    public override int Attack { get; protected set; }
    public override int Defense { get; protected set; }
    public override float MoveSpeed { get; protected set; }
    public override BaseState CurrentState { get; protected set; }
    public override bool IsAttacking { get; set; }
    public override bool Attacked { get; set; }

    private Slider m_lifeBar;

    protected override void Start()
    {
        m_lifeBar = GetComponentInChildren<Slider>();

        MaxLife = m_monsterData.Life;
        CurrentLife = m_monsterData.Life;
        Attack = m_monsterData.Attack;
        Defense = m_monsterData.Defense;
        MoveSpeed = m_monsterData.MoveSpeed;

        CurrentState.Enter(this);
    }

    protected override void Update()
    {
        CurrentState.LogicUpdate();
    }

    protected override void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
    }

    public override void EnterNewState(BaseState newState)
    {
        CurrentState.Exit();
        newState.Enter(this);
        CurrentState = newState;
    }

    public void Damage(int damage)
    {
    }

    public void Die()
    {
    }
}