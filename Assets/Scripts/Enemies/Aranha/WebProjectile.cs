using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class WebProjectile : MonoBehaviour
{
    private Rigidbody2D m_webRigidBody;
    private Animator m_webAnimator;

    private bool m_collided;
    [SerializeField] private float m_timeToVanish;
    [SerializeField] private GameEvent m_playerCatched;

    [SerializeField] private float m_forceScalar;

    private void Start()
    {
        m_webRigidBody = GetComponent<Rigidbody2D>();
        m_webAnimator = GetComponent<Animator>();

        m_webRigidBody.AddForce(-transform.up * m_forceScalar, ForceMode2D.Impulse);

        transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("CameraConfiner") && !collision.CompareTag("Enemy") && !m_collided)
        {
            m_webAnimator.SetTrigger("Open");
            m_webRigidBody.velocity = Vector3.zero;
            m_collided = true;
            StartCoroutine(nameof(TimeToWebVanish));
        }

        if (collision.transform.TryGetComponent(out PlayerController playerController)) m_playerCatched.Raise();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            playerController.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    private IEnumerator TimeToWebVanish()
    {
        yield return new WaitForSeconds(m_timeToVanish);

        DestroyWeb();
    }

    public void DestroyWeb() => Destroy(gameObject);
}