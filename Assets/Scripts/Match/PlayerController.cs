using Pinbattlers.Match;
using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject]
    private PlayerData m_playerData;

    private List<Condition> m_conditions;

    [SerializeField] private int m_maxLife;
    [field: SerializeField] public int Life { get; private set; }
    [SerializeField] private int m_attack;
    [SerializeField] private int m_defense;

    [SerializeField] private int m_leftBalls;

    private Vector2 m_respawnPosition;

    private Sprite m_skin;

    [SerializeField] private FloatEvent m_playerLifeUpdate;

    private void Start()
    {
        Life = m_playerData.Life + m_playerData.LifeModifier;
        m_maxLife = Life;
        m_attack = m_playerData.Attack + m_playerData.AttackModifier;
        m_defense = m_playerData.Defense;
        m_skin = m_playerData.SkinEquiped;
        m_respawnPosition = transform.position;

        m_leftBalls = 2;
    }

    private void Update()
    {
        if (m_conditions != null && m_conditions.Count > 0)
        {
            for (int i = 0; i < 5; i++)
            {
                m_conditions[i].UpdateCondition();
                if (m_conditions[i].RemainingTime <= 0)
                {
                    m_conditions[i].OnExit();
                    m_conditions.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    public void AddCondition(Condition condition)
    {
        m_conditions.Add(condition);
        condition.OnEnter(this);
    }

    public void TakeDamage(int damage)
    {
        Life -= damage - m_defense <= 0 ? 1 : damage - m_defense;

        if (Life <= 0) Die();

        Debug.Log((float)Life / m_maxLife);
        m_playerLifeUpdate.Invoke((float)Life / m_maxLife);
    }

    public void Heal(int heal)
    {
        if (Life + heal > m_maxLife) heal -= Life + heal - m_maxLife;

        Life += heal;

        m_playerLifeUpdate.Invoke((float)Life / m_maxLife);
    }

    public void RecoverBall(int ballsRecovered)
    {
        m_leftBalls += m_leftBalls + ballsRecovered > 4 ? 4 - m_leftBalls : ballsRecovered;
        MatchManager.Instance.ChangeRemainingBallsShowing(m_leftBalls);
    }

    public void Die()
    {
        transform.position = m_respawnPosition;
        Heal(m_maxLife - Life);

        if (m_leftBalls == 0) MatchManager.Instance.GameOver();
        else
        {
            m_leftBalls -= 1;
            MatchManager.Instance.ChangeRemainingBallsShowing(m_leftBalls);
        }
    }
}