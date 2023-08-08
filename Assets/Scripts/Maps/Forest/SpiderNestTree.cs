using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class SpiderNestTree : MonoBehaviour
{
    [SerializeField] private int m_pointsReward;
    [SerializeField] private IntGameEvent m_increasePoints;

    [SerializeField] private GameEvent m_sceneryTransition;
    private bool m_entered;

    [SerializeField] private WebObstacle m_obstacle;
    private Collider2D m_lock;

    private void Start() => m_lock = GetComponent<PolygonCollider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            if (!m_entered)
            {
                m_sceneryTransition.Raise();
                m_entered = true;
                m_lock.enabled = true;
            }
            else
            {
                m_entered = false;
                m_lock.enabled = false;
                StartCoroutine(nameof(ReturnWeb));
            }
        }
    }

    private IEnumerator ReturnWeb()
    {
        yield return new WaitForSeconds(2.5f);

        m_obstacle.ReturnToInitialState();
    }
}