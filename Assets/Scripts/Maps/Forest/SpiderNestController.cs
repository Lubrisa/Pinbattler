using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class SpiderNestController : MonoBehaviour
{
    [SerializeField] private GameObject m_spiderPrefab;
    [SerializeField] private Transform m_player;
    [SerializeField] private Transform m_spawnPoint;

    [SerializeField] private GameEvent m_sceneryTransition;

    private void OnEnable()
    {
        Instantiate(m_spiderPrefab, Vector3.zero, Quaternion.identity, transform);
        m_player.position = m_spawnPoint.position;
    }

    public void StartTransition() => StartCoroutine(nameof(ForestNestScene));

    private IEnumerator ForestNestScene()
    {
        yield return new WaitForSeconds(2f);

        m_sceneryTransition.Raise();
    }
}