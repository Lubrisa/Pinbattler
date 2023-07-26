using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitAtlasConfirmBehaviour : ConfirmBehaviour
{
    public override void Confirm()
    {
        SceneManager.LoadScene(0);
    }
}
