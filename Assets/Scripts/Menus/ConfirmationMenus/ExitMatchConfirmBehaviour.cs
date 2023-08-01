using Pinbattlers.Match;
using ScriptableObjectArchitecture;
using UnityEngine;

public class ExitMatchConfirmBehaviour : MonoBehaviour
{
    [SerializeField] private GameEvent m_gameOver;

    public void OnConfirm()
    {
        m_gameOver.Raise();
        Destroy(gameObject);
    }

    public void OnDecline()
    {
        Destroy(gameObject);
    }
}