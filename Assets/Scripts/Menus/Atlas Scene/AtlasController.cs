using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasController : MonoBehaviour
{
    [SerializeField] private GameObject m_confirmationMenuExit;

    public void OnExitButtonClick()
    {
        Instantiate(m_confirmationMenuExit);
    }
}
