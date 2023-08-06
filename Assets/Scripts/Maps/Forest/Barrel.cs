using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private int m_timesHit;
    [SerializeField] private GameObject m_tatuPrefab;

    [SerializeField] private BoolVariable m_isMonsterSpawned;

    [SerializeField] private int m_pointsReward;
    [SerializeField] private IntGameEvent m_increasePoints;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            if (m_timesHit < 3)
            {
                m_timesHit++;
                m_increasePoints.Raise(m_pointsReward);
            }
            else if (!m_isMonsterSpawned)
            {
                Debug.Log("Spawn");
                m_timesHit = 0;
                m_isMonsterSpawned.Value = true;
            }
        }
    }
}