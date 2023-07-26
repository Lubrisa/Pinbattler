using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationMenuController : MonoBehaviour
{
    [SerializeField] private IConfirmBehaviour confirmBehaviour;

    public void OnConfirmButtonClick()
    {

    }

    public void OnDeclineButtonClick()
    {
        Destroy(this.gameObject);
    }
}