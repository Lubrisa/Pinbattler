using Pinbattlers.Match;
using UnityEngine;

public class ExitMatchConfirmBehaviour : MonoBehaviour
{
    public void OnConfirm()
    {
        MatchManager.Instance.EndMatch();
        Destroy(gameObject);
    }

    public void OnDecline()
    {
        Destroy(gameObject);
    }
}