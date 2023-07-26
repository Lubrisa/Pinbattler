using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitAtlasConfirmBehaviour : ScriptableObject, IConfirmBehaviour
{
    public void Confirm()
    {
        SceneManager.LoadScene(0);
    }
}
