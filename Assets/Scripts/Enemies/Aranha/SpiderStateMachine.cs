using Pinbattlers.Enemies;
using Pinbattlers.Menus;
using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;
using Zenject.SpaceFighter;

public class SpiderStateMachine : BaseStateMachine, IEnemy
{
    [SerializeField] private MonsterData m_monsterData;

    #region Attributes

    public override int MaxLife { get; protected set; }
    public override int CurrentLife { get; protected set; }
    public override int Attack { get; protected set; }
    public override int Defense { get; protected set; }
    public override float MoveSpeed { get; protected set; }

    #endregion Attributes

    [field: SerializeField] public override BaseState CurrentState { get; protected set; }

    public override bool IsAttacking { get; set; }
    public override bool Attacked { get; set; }

    #region Components

    private Slider m_lifeBar;

    #endregion Components

    #region Events

    [SerializeField] private IntGameEvent m_givePoints;
    [SerializeField] private int m_pointsReward;
    [SerializeField] private int m_essencesReward;

    #endregion Events

    private GameObject m_player;

    [SerializeField] private BaseState m_attackState;

    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private float m_rotationModifier;
    [SerializeField] private GameObject m_portalWeb;

    protected override void Start()
    {
        m_lifeBar = GetComponentInChildren<Slider>();

        MaxLife = m_monsterData.Life;
        CurrentLife = m_monsterData.Life;
        Attack = m_monsterData.Attack;
        Defense = m_monsterData.Defense;
        MoveSpeed = m_monsterData.MoveSpeed;

        m_player = GameObject.FindGameObjectWithTag("Player");

        CurrentState.Enter(this);
    }

    protected override void Update()
    {
        RotateTowardsPlayer();

        CurrentState.LogicUpdate();
    }

    private void RotateTowardsPlayer()
    {
        Vector3 vectorToTarget = m_player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - m_rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * m_rotationSpeed);
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

    public void StartAttacking() => EnterNewState(m_attackState);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAttacking && collision.transform.TryGetComponent(out PlayerController playerController))
        {
            Attacked = true;
            playerController.TakeDamage(Attack);
        }
    }

    public void Damage(int damage)
    {
        if (!IsAttacking)
        {
            CurrentLife -= (damage - Defense > 0) ? damage - Defense : 1;

            m_lifeBar.value = (float)CurrentLife / MaxLife;

            if (CurrentLife <= 0) Die();
        }
    }

    [ContextMenu("Kill")]
    public void Die()
    {
        m_givePoints.Raise(m_pointsReward);
        GameOverMenuController.Instance.Essences += m_essencesReward;

        m_monsterData.QuantityKilled++;

        Instantiate(m_portalWeb, transform.position, Quaternion.identity, transform.parent);

        Destroy(this.gameObject);
    }
}