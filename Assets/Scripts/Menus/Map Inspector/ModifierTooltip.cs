using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Pinbattlers.Menus
{
    public class ModifierTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject m_tooltip;
        [SerializeField] private TMP_Text m_tooltiptext;

        [SerializeField] private int index;

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_tooltip.SetActive(true);
            m_tooltiptext.text = MapInspectorController.MapData[MapInspectorController.MapIndex].MapModifiers[index].Description;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_tooltip.SetActive(false);
        }
    }
}