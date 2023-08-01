using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Pinbattlers.Menus
{
    public class PauseMenuController : MonoBehaviour
    {
        private GameObject m_pauseMenu;

        public bool OptionsMenuActive { get; set; }

        [SerializeField] private GameObject m_confirmationMenu;

        [Inject]
        private void Constructor([Inject(Id = "PauseMenu")] RectTransform pauseMenu) => m_pauseMenu = pauseMenu.gameObject;

        private void Start()
        {
            PlayerInputs playerInputs = new PlayerInputs();
            playerInputs.Enable();
            playerInputs.Computer.Pause.performed += SetPauseMenuState;
        }

        public void OnContinueButtonClick()
        {
            SetPauseMenuState(new InputAction.CallbackContext());
        }

        public void OnExitMatchButtonClick()
        {
            Instantiate(m_confirmationMenu);
        }

        private void SetPauseMenuState(InputAction.CallbackContext action)
        {
            if (!m_pauseMenu.activeSelf)
            {
                m_pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else if (!OptionsMenuActive)
            {
                m_pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}