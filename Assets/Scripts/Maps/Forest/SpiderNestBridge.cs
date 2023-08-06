using Pinbattlers.Player;
using UnityEngine;

public class SpiderNestBridge : MonoBehaviour
{
    [SerializeField] private Collider2D m_impulseCollider;
    [SerializeField] private Collider2D m_exitCollider;
    [SerializeField] private Collider2D m_lateralColliders;
    [SerializeField] private Collider2D m_bridgeCollider;
    private SpriteRenderer m_bridgeSprite;

    [SerializeField] private float m_impulseX;
    [SerializeField] private float m_impulseY;

    private bool m_isActive = false;

    private void Start() => m_bridgeSprite = GetComponent<SpriteRenderer>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            if (!m_isActive)
            {
                m_bridgeCollider.enabled = true;
                m_lateralColliders.enabled = false;
                m_impulseCollider.enabled = false;
                m_exitCollider.enabled = true;
                m_bridgeSprite.sortingOrder = 0;

                collision.TryGetComponent(out Rigidbody2D playerRigidBody);
                playerRigidBody.AddForce(new Vector3(m_impulseX, m_impulseY), ForceMode2D.Impulse);

                m_isActive = true;
            }
            else
            {
                m_bridgeCollider.enabled = false;
                m_impulseCollider.enabled = true;
                m_lateralColliders.enabled = true;
                m_exitCollider.enabled = false;
                m_bridgeSprite.sortingOrder = 2;

                m_isActive = false;
            }
        }
    }
}