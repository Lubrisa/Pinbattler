using UnityEngine;
using UnityEngine.EventSystems;

namespace Pinbattlers.Menus
{
    public class ModifierController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ModifierTooltip m_tooltip;
        [SerializeField] private ModifierTooltip m_tooltipInstance;

        private int m_index;
        public MapsData MapData { get; set; }

        public void SetIndex()
        {
            int index = 0;
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (!transform.parent.GetChild(i).gameObject.activeSelf) index--;
                else if (transform.parent.GetChild(i).gameObject == gameObject)
                {
                    index += i;
                    break;
                }
            }

            m_index = index;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_tooltipInstance = Instantiate(m_tooltip, transform);
            m_tooltipInstance.SetText(MapData.MapModifiers[m_index].Description);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Destroy(m_tooltipInstance.gameObject);
        }

        public void OnModifierToggleValueChange(bool value) => MapData.MapModifiers[m_index].IsEnabled = value;
    }
}