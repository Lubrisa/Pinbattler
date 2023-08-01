using TMPro;
using UnityEngine;

namespace Pinbattlers.Menus
{
    public class ModifierTooltip : MonoBehaviour
    {
        private TMP_Text m_text;
        private RectTransform m_rectTransform;
        private Canvas m_canvas;
        [SerializeField] private Vector3 m_offset;
        [SerializeField] private float padding;

        private void OnEnable()
        {
            m_text = GetComponentInChildren<TextMeshProUGUI>();
            m_rectTransform = GetComponent<RectTransform>();
            m_canvas = GetComponent<Canvas>();
        }

        private void Update()
        {
            Vector3 newPosition = Input.mousePosition + m_offset;
            newPosition.z = 0;
            float rightEdgeToScreenDistance = Screen.width - (newPosition.x + m_rectTransform.rect.width * m_canvas.scaleFactor / 2) - padding;
            if (rightEdgeToScreenDistance < 0) newPosition.x += rightEdgeToScreenDistance;

            float leftEdgeToScreenDistance = 0 - (newPosition.x - m_rectTransform.rect.width * m_canvas.scaleFactor / 2) + padding;
            if (leftEdgeToScreenDistance > 0) newPosition.x += leftEdgeToScreenDistance;

            float topEdgeToScreenDistance = Screen.height - (newPosition.y + m_rectTransform.rect.height * m_canvas.scaleFactor) - padding;
            if (topEdgeToScreenDistance < 0) newPosition.y += topEdgeToScreenDistance;

            m_rectTransform.transform.position = newPosition;
        }

        public void SetText(string text)
        {
            m_text.text = text;
        }
    }
}