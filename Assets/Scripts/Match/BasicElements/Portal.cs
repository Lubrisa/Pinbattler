using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameEvent m_startTransition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            StartCoroutine(nameof(CallTransition));
        }
    }

    private IEnumerator CallTransition()
    {
        yield return new WaitForSeconds(3f);
        m_startTransition.Raise();
    }

    private void OnDisable() => Destroy(gameObject);
}