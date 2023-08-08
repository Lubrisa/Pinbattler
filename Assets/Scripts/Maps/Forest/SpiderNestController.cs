using UnityEngine;

public class SpiderNestController : MonoBehaviour
{
    [SerializeField] private GameObject m_spiderPrefab;
    [SerializeField] private Transform m_player;
    [SerializeField] private Transform m_spawnPoint;
    [SerializeField] private WebObstacle m_entryWeb;

    private void OnEnable()
    {
        Instantiate(m_spiderPrefab, Vector3.zero, Quaternion.identity, transform);
        m_player.position = m_spawnPoint.position;
        m_entryWeb.ReturnToInitialState();
    }
}