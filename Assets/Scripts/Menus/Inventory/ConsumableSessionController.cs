using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class ConsumableSessionController : MonoBehaviour, IInfoUpdatable
    {
        [Inject]
        private PlayerData m_instance;

        [SerializeField] private Transform m_content;

        [SerializeField] private TMP_Text m_consumableName;
        [SerializeField] private TMP_Text m_consumableLoreDescription;
        [SerializeField] private TMP_Text m_consumableMechanicDescription;
        [SerializeField] private Image m_consumableIllustration;
        [SerializeField] private TMP_Text m_consumableQuantity;
        [SerializeField] private TMP_Text m_consumableRarity;

        [SerializeField] private ItemFill m_itemInstance;
        private int m_itemInspectedIndex;

        public void FillContent()
        {
            if (m_content.childCount == m_instance.Consumables.Count) return;

            for (int i = m_content.childCount; i < m_instance.Consumables.Count; i++)
            {
                m_itemInstance = Instantiate(m_itemInstance, m_content);
                m_itemInstance.FillContent(i, this, m_instance);
            }

            UpdateInfo(0);
        }

        public void UpdateInfo(int itemIndex)
        {
            m_itemInspectedIndex = itemIndex;

            m_consumableName.text = m_instance.Consumables[itemIndex].Name;
            m_consumableLoreDescription.text = m_instance.Consumables[itemIndex].LoreDescription;
            m_consumableMechanicDescription.text = m_instance.Consumables[itemIndex].MechanicDescription;
            m_consumableIllustration.sprite = m_instance.Consumables[itemIndex].Icon;
            m_consumableQuantity.text = "Quantidade no Inventário: " + m_instance.Consumables[itemIndex].Quantity.ToString();
            m_consumableRarity.text = m_instance.Consumables[itemIndex].ItemRarity.RarityName;
        }
    }
}