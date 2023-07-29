using System;
using System.Collections;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private bool m_isLeft;

    [SerializeField] private float m_force;
    private Rigidbody2D m_rigidbody;

    private PlayerInputs m_playerInputs;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();

        m_playerInputs = new PlayerInputs();
        m_playerInputs.Enable();

        if (!m_isLeft) m_force *= -1;
    }

    private void FixedUpdate()
    {
        if (m_playerInputs.Computer.LeftFlipper.inProgress && m_isLeft || m_playerInputs.Computer.RightFlipper.inProgress && !m_isLeft)
        {
            m_rigidbody.AddTorque(m_force);
        }
    }
}