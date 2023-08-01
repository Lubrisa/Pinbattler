using TMPro;
using UnityEngine;

namespace Pinbattlers.Menus
{
    public class ModifierTooltip : MonoBehaviour
    {
        private TMP_Text m_text;

        private RectTransform m_rectTransform;
        [SerializeField] private Vector3 m_offset;

        private void OnEnable()
        {
            m_text = GetComponentInChildren<TextMeshProUGUI>();
            m_rectTransform = GetComponent<RectTransform>();
        }

        public void SetText(string text)
        {
            m_text.text = text;
        }
    }
}