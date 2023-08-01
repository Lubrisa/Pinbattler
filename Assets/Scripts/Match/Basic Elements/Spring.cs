using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float m_maxForce;
    private float m_force;
    [SerializeField] private float m_forceIncreaseRate;

    private PlayerInputs m_playerInputs;

    private bool m_isInContactWithBall;
    private Rigidbody2D m_ballRigidbody;

    private void Start()
    {
        m_playerInputs = new PlayerInputs();

        m_playerInputs.Enable();
    }

    private void Update()
    {
        if (m_playerInputs.Computer.Spring.inProgress)
        {
            m_force += m_force < m_maxForce ? m_forceIncreaseRate * Time.deltaTime : 0;
        }
        else if (m_force > 0)
        {
            if (m_isInContactWithBall)
            {
                m_ballRigidbody.AddForce(new Vector2(0, m_force), ForceMode2D.Impulse);
            }

            m_force = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.TryGetComponent(out PlayerController playerController))
        {
            m_isInContactWithBall = true;
            m_ballRigidbody = collider.transform.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.TryGetComponent(out PlayerController playerController))
        {
            m_isInContactWithBall = false;
        }
    }
}