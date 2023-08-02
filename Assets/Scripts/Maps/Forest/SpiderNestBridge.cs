using Pinbattlers.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderNestBridge : MonoBehaviour
{
    private Collider2D m_impulseCollider;
    private Collider2D m_lateralColliders;
    [SerializeField] private Collider2D m_bridgeCollider;
    private SpriteRenderer m_bridgeSprite;

    private void Start()
    {
        m_impulseCollider = GetComponent<BoxCollider2D>();
        m_lateralColliders = GetComponent<PolygonCollider2D>();
        m_bridgeSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_bridgeCollider.enabled = true;
        m_impulseCollider.enabled = false;
        m_lateralColliders.enabled = false;
        m_bridgeSprite.sortingOrder = 0;

        collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D playerRigidBody);
        playerRigidBody.AddForce(new Vector3(20f, 10f), ForceMode2D.Impulse);

        StartCoroutine(nameof(WaitForBallToReturn), 0f);
    }

    IEnumerator WaitForBallToReturn()
    {
        yield return new WaitForSeconds(4f);

        m_bridgeCollider.enabled = false;
        m_impulseCollider.enabled = true;
        m_lateralColliders.enabled = true;
        m_bridgeSprite.sortingOrder = 2;
    }
}
