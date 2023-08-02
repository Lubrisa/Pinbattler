using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceLock : MonoBehaviour
{
    private GameObject m_block;

    void Start()
    {
        m_block = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision) => m_block.SetActive(true);

    public void OnPlayerDeath() => m_block.SetActive(false);
}
