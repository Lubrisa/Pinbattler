using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAtlasButtonController : MonoBehaviour
{
    [SerializeField] private GameObject m_exitAtlasConfirmationMenu;

    public void OpenConfirmationMenu() => Instantiate(m_exitAtlasConfirmationMenu);
}