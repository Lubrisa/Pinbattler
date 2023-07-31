using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAtlasButtonController : MonoBehaviour
{
    [SerializeField] private GameObject m_exitAtlasConfirmationMenu;

    public void OnExitButtonClick()
    {
        Instantiate(m_exitAtlasConfirmationMenu);
    }
}