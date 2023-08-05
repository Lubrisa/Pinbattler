using Pinbattlers.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderNestTree : MonoBehaviour
{
    private int m_timesHit = 0;
    private SpriteRenderer m_spriteRenderer;
    private Sprite[] m_webSprites;
    private Collider2D m_webCollider;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_webCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            m_timesHit++;

            m_spriteRenderer.sprite = m_webSprites[m_timesHit];

            if (m_timesHit == 3)
            {
                m_webCollider.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController)) SceneManager.LoadScene("SpiderNest");
    }
}