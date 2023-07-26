using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationMenuController : MonoBehaviour
{
    [SerializeField] private ConfirmBehaviour m_confirmBehaviour;

    public void OnConfirmButtonClick()
    {
        m_confirmBehaviour.Confirm();
    }

    public void OnDeclineButtonClick()
    {
        Destroy(this.gameObject);
    }
}