using UnityEngine;
using Zenject;

namespace Pinbattlers.Menus
{
    public class OptionsMenuController : MonoBehaviour
    {
        private RectTransform[] m_sessions;
        private int m_activeSessionIndex;

        [Inject]
        private void Contructor(RectTransform[] sessions)
        {
            m_sessions = sessions;

            ChangeActiveSession(0);
        }

        public void ChangeActiveSession(int sessionIndex)
        {
            if (m_activeSessionIndex != sessionIndex)
            {
                m_sessions[sessionIndex].gameObject.SetActive(true);
                m_sessions[m_activeSessionIndex].gameObject.SetActive(false);
                m_activeSessionIndex = sessionIndex;
            }
        }
    }
}