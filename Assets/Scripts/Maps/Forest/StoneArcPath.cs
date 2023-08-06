using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using UnityEngine;

public class StoneArcPath : MonoBehaviour
{
    [SerializeField] private Collider2D m_pathCollider;
    private bool m_entered;

    [SerializeField] private int m_pointsReward;
    [SerializeField] private IntGameEvent m_increasePoints;

    [SerializeField] private Transform m_entrancePoint;
    [SerializeField] private Transform m_exitPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            float distanceToPathEntrance = Vector2.Distance(collision.transform.position, m_entrancePoint.position);
            if (distanceToPathEntrance < 1f) m_entered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (m_entered && collision.transform.TryGetComponent(out PlayerController playerController))
        {
            m_entered = false;

            float distanceToPathExit = Vector2.Distance(collision.transform.position, m_exitPoint.position);
            if (distanceToPathExit < 1f) m_increasePoints.Raise(m_pointsReward);
        }
    }
}