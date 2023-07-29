using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CreditsSceneController : MonoBehaviour
{
    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();

        PlayerInputs playerInputs = new PlayerInputs();
        playerInputs.Computer.Enable();
        playerInputs.Computer.Skip.performed += SkipCredits;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartWarningAnimation();
        }
    }

    public void StartWarningAnimation()
    {
        if (!m_animator.GetBool("Warning"))
        {
            m_animator.SetBool("Warning", true);
        }
    }

    public void EndWarningAnimation()
    {
        m_animator.SetBool("Warning", false);
    }

    private void SkipCredits(InputAction.CallbackContext context)
    {
        EndCredits();
    }

    public void EndCredits()
    {
        SceneManager.LoadScene(0);
    }
}