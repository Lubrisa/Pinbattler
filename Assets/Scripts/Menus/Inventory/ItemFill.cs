using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class ItemFill : MonoBehaviour, IPointerClickHandler
    {
        private PlayerData m_instance;

        private enum ItemType
        {
            Relic,
            Consumable
        }

        [SerializeField] private ItemType m_type;
        [SerializeField] private TMP_Text m_itemName;
        [SerializeField] private Image m_itemIllustration;

        private int m_itemIndex;
        private IInfoUpdatable m_controller;

        public void FillContent(int itemIndex, IInfoUpdatable controller, PlayerData instance)
        {
            m_instance = instance;
            m_itemIndex = itemIndex;
            m_controller = controller;

            if (m_type == ItemType.Relic)
            {
                m_itemName.text = m_instance.Relics[itemIndex].Name;
                m_itemIllustration.sprite = m_instance.Relics[itemIndex].Icon;
            }
            else
            {
                m_itemName.text = m_instance.Consumables[itemIndex].Name;
                m_itemIllustration.sprite = m_instance.Consumables[itemIndex].Icon;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_controller.UpdateInfo(m_itemIndex);
        }
    }
}