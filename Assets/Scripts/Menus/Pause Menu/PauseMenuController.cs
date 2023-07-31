using Pinbattlers.Match;
using Pinbattlers.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pinbattlers.Menus
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject m_menu;

        [SerializeField] private GameObject m_missionTextHolder;
        [SerializeField] private Transform m_content;

        [SerializeField] private GameObject m_confirmationMenu;

        public bool OptionsMenuActive { get; set; }

        private void Start()
        {
            PlayerInputs playerInputs = new PlayerInputs();
            playerInputs.Enable();
            playerInputs.Computer.Pause.performed += SetPauseMenuState;
        }

        private void SetPauseMenuState(InputAction.CallbackContext action)
        {
            if (!m_menu.activeSelf)
            {
                m_menu.SetActive(true);
                SetMissions();
                Time.timeScale = 0;
            }
            else if (!OptionsMenuActive)
            {
                m_menu.SetActive(false);
                EraseMissions();
                Time.timeScale = 1;
            }
        }

        public void OnContinueButtonClick()
        {
            SetPauseMenuState(new InputAction.CallbackContext());
        }

        private void SetMissions()
        {
            TMP_Text text;

            if (MatchManager.Instance.Challenges != null)
            {
                foreach (BaseChallenge c in MatchManager.Instance.Challenges)
                {
                    text = Instantiate(m_missionTextHolder, m_content).GetComponentInChildren<TMP_Text>();
                    text.text = c.Description;
                }
            }

            if (MatchManager.Instance.Modifiers != null)
            {
                foreach (BaseDifficultyModifier dm in MatchManager.Instance.Modifiers)
                {
                    text = Instantiate(m_missionTextHolder, m_content).GetComponentInChildren<TMP_Text>();
                    text.text = dm.Description;
                }
            }
        }

        public void EraseMissions()
        {
            if (m_content.childCount > 0)
            {
                for (int i = m_content.childCount - 1; i >= 0; i--)
                {
                    Destroy(m_content.GetChild(i).gameObject);
                }
            }
        }

        public void OnExitMatchButtonClick()
        {
            Instantiate(m_confirmationMenu);
        }
    }
}