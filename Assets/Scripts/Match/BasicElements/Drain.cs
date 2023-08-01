using Pinbattlers.Player;
using UnityEngine;

public class Drain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController playerController))
        {
            playerController.Die();
        }
    }
}