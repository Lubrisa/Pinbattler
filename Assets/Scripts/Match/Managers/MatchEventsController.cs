using UnityEngine;

namespace Pinbattlers.Match
{
    public class MatchEventsController : MonoBehaviour
    {
        private BaseMatchEvent m_event;

        private BaseMatchEvent m_modifierEvent;

        public void SetModifierEvent(BaseMatchEvent value)
        {
            if (m_modifierEvent == null) m_modifierEvent = value;
        }

        private void Update()
        {
            m_event?.Effect();
            m_modifierEvent?.Effect();
        }

        public void SwitchMatchEvent(BaseMatchEvent matchEvent)
        {
            m_event?.Exit();
            matchEvent.Enter();
            m_event = matchEvent;
        }
    }
}