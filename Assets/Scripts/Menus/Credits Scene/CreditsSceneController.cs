using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CreditsSceneController : MonoBehaviour
{
    private void Start()
    {
        PlayerInputs playerInputs = new PlayerInputs();

        playerInputs.Computer.Enable();
        playerInputs.Computer.Skip.performed += EndCredits;
    }

    public void EndCredits(InputAction.CallbackContext context)
    {
        print("Segurou");
        SceneManager.LoadScene(0);
    }
}
