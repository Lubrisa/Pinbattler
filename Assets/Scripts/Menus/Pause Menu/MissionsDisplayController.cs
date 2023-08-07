using Pinbattlers.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Pinbattlers.Menus
{
    public class MissionsDisplayController : MonoBehaviour
    {
        [Inject]
        private MapData m_mapData;

        [SerializeField] private GameObject m_missionTextHolder;
        private Transform m_content;

        private bool m_isActive;

        private PauseMenuController m_pauseMenu;

        [Inject]
        private void Constructor(RectTransform content)
        {
            m_pauseMenu = transform.GetComponentInParent<PauseMenuController>();
            m_content = content;

            PlayerInputs playerInputs = new PlayerInputs();
            playerInputs.Computer.Enable();
            playerInputs.Computer.Pause.performed += OnEscapePressed;

            OnEscapePressed(new InputAction.CallbackContext());
        }

        private void OnEscapePressed(InputAction.CallbackContext context)
        {
            if (!m_pauseMenu.OptionsMenuActive)
            {
                if (m_isActive)
                {
                    WriteMissions();
                    m_isActive = false;
                }
                else
                {
                    EraseMissions();
                    m_isActive = true;
                }
            }
        }

        private void WriteMissions()
        {
            TMP_Text text;

            foreach (BaseChallenge c in m_mapData.MapChallenges)
            {
                if (!c.Concluded)
                {
                    text = Instantiate(m_missionTextHolder, m_content).GetComponentInChildren<TMP_Text>();
                    text.text = c.Description;
                }
            }

            foreach (BaseDifficultyModifier dm in m_mapData.MapModifiers)
            {
                if (!dm.Concluded)
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
    }
}