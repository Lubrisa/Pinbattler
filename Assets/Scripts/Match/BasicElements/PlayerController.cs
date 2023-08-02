using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pinbattlers.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Properties

        [Inject]
        private PlayerData m_playerData;

        private int m_maxLife;
        public int Life { get; private set; }
        private int m_attack;
        private int m_defense;
        private int m_leftBalls;
        private Vector2 m_respawnPosition;

        private List<Condition> m_conditions;

        [SerializeField] private FloatGameEvent m_playerLifeUpdate;
        [SerializeField] private IntGameEvent m_playerRemainingBallsUpdate;
        [SerializeField] private GameEvent m_gameOver;
        [SerializeField] private GameEvent m_death;

        #endregion Properties

        #region Initialization

        private void Start()
        {
            // Setting main attributes
            Life = m_playerData.Life + m_playerData.LifeModifier;
            m_maxLife = Life;
            m_leftBalls = 4;
            m_playerRemainingBallsUpdate.Raise(m_leftBalls);
            m_attack = m_playerData.Attack + m_playerData.AttackModifier;
            m_defense = m_playerData.Defense;
            m_respawnPosition = transform.position;
            // Setting skin
            GetComponent<SpriteRenderer>().sprite = m_playerData.SkinEquiped; ;
        }

        #endregion Initialization

        #region Conditions

        private void Update()
        {
            if (m_conditions != null && m_conditions.Count > 0) ApplyConditions();
        }

        private void ApplyConditions()
        {
            for (int i = 4; i >= 0; i--)
            {
                m_conditions[i].UpdateCondition();
                if (m_conditions[i].RemainingTime <= 0)
                {
                    m_conditions[i].OnExit();
                    m_conditions.RemoveAt(i);
                }
            }
        }

        public void AddCondition(Condition condition)
        {
            if (m_conditions.Contains(condition) && m_conditions[m_conditions.IndexOf(condition)].StackFactor < 3)
            {
                m_conditions[m_conditions.IndexOf(condition)].OnStack();
            }
            else
            {
                m_conditions.Add(condition);
                condition.OnEnter(this);
            }
        }

        #endregion Conditions

        #region CollisionAndDamage

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamageable damageable = collision.transform.GetComponent<IDamageable>();

            if (damageable != null) damageable.Damage(m_attack);
        }

        #endregion CollisionAndDamage

        #region LifeManagement

        public void TakeDamage(int damage)
        {
            Life -= damage - m_defense <= 0 ? 1 : damage - m_defense;

            if (Life <= 0) Die();

            m_playerLifeUpdate.Raise((float)Life / m_maxLife);
        }

        public void Heal(int heal)
        {
            Life += Mathf.Clamp(Life + heal, 0, m_maxLife);

            m_playerLifeUpdate.Raise((float)Life / m_maxLife);
        }

        public void ChangeBallValue(int ballChange)
        {
            m_leftBalls = Mathf.Clamp(m_leftBalls + ballChange, -1, 4);
            m_playerRemainingBallsUpdate.Raise(m_leftBalls);
        }

        public void Die()
        {
            transform.position = m_respawnPosition;
            Heal(m_maxLife - Life);
            ChangeBallValue(-1);

            m_death.Raise();

            if (m_leftBalls < 0) m_gameOver.Raise();
        }

        #endregion LifeManagement
    }
}