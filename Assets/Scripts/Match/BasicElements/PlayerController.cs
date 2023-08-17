using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Pinbattlers.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Properties

        public static PlayerController Instance { get; private set; }
        [SerializeField] private bool m_isOneCopy;

        [Inject]
        private PlayerData m_playerData;

        private int m_maxLife;
        [field: SerializeField] public int Life { get; private set; }
        private int m_attack;
        private int m_defense;
        private int m_leftBalls;
        private Vector2 m_respawnPosition;

        private List<Condition> m_conditions;

        [SerializeField] private FloatVariable m_saverTime;
        private bool m_isSaverActive;

        [SerializeField] private FloatGameEvent m_playerLifeUpdate;
        [SerializeField] private IntGameEvent m_playerRemainingBallsUpdate;
        [SerializeField] private GameEvent m_gameOver;
        [SerializeField] private GameEvent m_death;

        #endregion Properties

        #region Initialization

        private void Awake()
        {
            Debug.Log("Awake");
            if (Instance == null) Instance = this;
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable");
            if (Instance != this && m_isOneCopy) CopyDataFromOriginalInstance();
            else
            {
                Debug.Log("First Instance");
                // Setting main attributes.
                Life = m_playerData.Life + m_playerData.LifeModifier;
                m_maxLife = Life;
                m_playerRemainingBallsUpdate.Raise(m_leftBalls);
                m_attack = m_playerData.Attack + m_playerData.AttackModifier;
                m_defense = m_playerData.Defense;
                m_leftBalls = 2;
            }
            GetComponent<SpriteRenderer>().sprite = m_playerData.SkinEquiped;

            m_saverTime.AddListener(StartSaverTimer);
        }

        private void Start()
        {
            Debug.Log("Start");
            // Setting respawn position.
            m_respawnPosition = transform.position;
            m_playerRemainingBallsUpdate.Raise(m_leftBalls);
        }

        public void CopyDataFromOriginalInstance()
        {
            Debug.Log("Copying Data");
            // The player data.
            m_playerData = Instance.m_playerData;
            // Attributes.
            m_maxLife = Instance.m_maxLife;
            Life = Instance.Life;
            m_attack = Instance.m_attack;
            m_defense = Instance.m_defense;
            m_leftBalls = Instance.m_leftBalls;
            m_conditions = Instance.m_conditions;
            // Events.
            m_playerLifeUpdate = Instance.m_playerLifeUpdate;
            m_playerRemainingBallsUpdate = Instance.m_playerRemainingBallsUpdate;
            m_gameOver = Instance.m_gameOver;
            m_death = Instance.m_death;

            Instance = this;
        }

        private void OnDisable() => m_saverTime.RemoveListener(StartSaverTimer);

        #endregion Initialization

        #region Conditions

        private void Update()
        {
            if (m_conditions != null && m_conditions.Count > 0) ApplyConditions();
        }

        private void ApplyConditions()
        {
            for (int i = 2; i >= 0; i--)
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
            Life = Life < 0 ? 0 : Life;

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

        public void StartSaverTimer()
        {
            if (!m_isSaverActive && m_saverTime.Value > 0)
            {
                m_isSaverActive = true;
                m_saverTime.RemoveListener(StartSaverTimer);
                StartCoroutine(nameof(SaverTimer));
            }
        }

        private IEnumerator SaverTimer()
        {
            while (m_saverTime.Value > 0)
            {
                m_saverTime.Value -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            m_isSaverActive = false;
            m_saverTime.AddListener(StartSaverTimer);
        }

        public void Die()
        {
            transform.position = m_respawnPosition;
            Heal(m_maxLife - Life);

            if (!m_isSaverActive) ChangeBallValue(-1);

            m_death.Raise();

            if (m_leftBalls < 0)
            {
                m_gameOver.Raise();
                gameObject.SetActive(false);
            }
        }

        #endregion LifeManagement
    }
}