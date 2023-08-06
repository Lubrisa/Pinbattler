using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class SpiderNestTree : MonoBehaviour
{
    private int m_timesHit = 0;
    private SpriteRenderer m_spriteRenderer;
    [SerializeField] private Sprite[] m_webSprites;
    private Collider2D m_webCollider;

    [SerializeField] private int m_pointsReward;
    [SerializeField] private IntGameEvent m_increasePoints;

    [SerializeField] private GameEvent m_sceneryTransition;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_webCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            if (m_timesHit < 3)
            {
                m_spriteRenderer.sprite = m_webSprites[m_timesHit];
                m_timesHit++;
                m_increasePoints.Raise(m_pointsReward);
            }
            else if (m_timesHit == 3)
            {
                m_webCollider.enabled = false;
                m_timesHit++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            m_webCollider.enabled = true;

            StartCoroutine(nameof(LoadSpiderNestScene));
        }
    }

    private IEnumerator LoadSpiderNestScene()
    {
        m_sceneryTransition.Raise();

        yield return new WaitForSeconds(2f);

        m_webCollider.enabled = false;
        m_spriteRenderer.sprite = m_webSprites[0];
        m_timesHit = 0;
    }
}