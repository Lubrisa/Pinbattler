using UnityEngine;

namespace Pinbattlers.Menus
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_sessions;

        private int m_currentOpenSession;

        public void ChangeSession(int sessionIndex)
        {
            if (sessionIndex != m_currentOpenSession)
            {
                m_sessions[sessionIndex].SetActive(true);
                m_sessions[m_currentOpenSession].SetActive(false);
                m_currentOpenSession = sessionIndex;
            }
        }
    }
}