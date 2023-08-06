using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    [SerializeField] private GameEvent m_startTransitionAnimation;

    [SerializeField] private Transform m_sceneryUnloaded;
    [SerializeField] private Transform m_sceneryLoaded;

    public void MakeTransition()
    {
        m_startTransitionAnimation.Raise();

        StartCoroutine(nameof(Transition));
    }

    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(2f);

        m_sceneryLoaded.gameObject.SetActive(true);
        m_sceneryUnloaded.gameObject.SetActive(false);
    }
}