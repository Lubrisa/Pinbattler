using Pinbattlers.Player;
using UnityEngine;

public class WebObstacle : MonoBehaviour
{
    private SpriteRenderer m_spriteRenderer;
    [SerializeField] private Sprite m_webSprite;
    private Collider2D m_collider;

    [SerializeField] private int m_hitsNecessaryToBreak;
    private int m_timesHit;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            if (m_timesHit < m_hitsNecessaryToBreak) m_timesHit++;
            else
            {
                m_spriteRenderer.sprite = null;
                m_collider.isTrigger = true;
            }
        }
    }

    public void ReturnToInitialState()
    {
        m_spriteRenderer.sprite = m_webSprite;
        m_collider.isTrigger = false;
        m_timesHit = 0;
    }
}