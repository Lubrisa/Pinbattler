using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pinbattlers.Menus
{
    public class ItemFill : MonoBehaviour, IPointerClickHandler
    {
        private PlayerData m_playerData;

        private enum ItemType
        {
            Relic,
            Consumable
        }

        [SerializeField] private ItemType m_type;
        [SerializeField] private TMP_Text m_itemName;
        [SerializeField] private Image m_itemIllustration;

        private int m_itemIndex;
        private IInfoUpdatable m_container;

        public void FillContent(int itemIndex, IInfoUpdatable container, PlayerData playerData)
        {
            m_playerData = playerData;
            m_itemIndex = itemIndex;
            m_container = container;

            if (m_type == ItemType.Relic)
            {
                m_itemName.text = m_playerData.Relics[itemIndex].Name;
                m_itemIllustration.sprite = m_playerData.Relics[itemIndex].IconSprite;
            }
            else
            {
                m_itemName.text = m_playerData.Consumables[itemIndex].Name;
                m_itemIllustration.sprite = m_playerData.Consumables[itemIndex].IconSprite;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_container.UpdateInfo(m_itemIndex);
        }
    }
}