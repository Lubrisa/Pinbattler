using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pinbattlers.Menus
{
    public class ConsumableSessionController : MonoBehaviour, IInfoUpdatable
    {
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
            if (m_content.childCount == PlayerData.Instance.Consumables.Count) return;

            for (int i = m_content.childCount; i < PlayerData.Instance.Consumables.Count; i++)
            {
                m_itemInstance = Instantiate(m_itemInstance, m_content);
                m_itemInstance.FillContent(i, this);
            }

            UpdateInfo(0);
        }

        public void UpdateInfo(int itemIndex)
        {
            m_itemInspectedIndex = itemIndex;

            m_consumableName.text = PlayerData.Instance.Consumables[itemIndex].Name;
            m_consumableLoreDescription.text = PlayerData.Instance.Consumables[itemIndex].LoreDescription;
            m_consumableMechanicDescription.text = PlayerData.Instance.Consumables[itemIndex].MechanicDescription;
            m_consumableIllustration.sprite = PlayerData.Instance.Consumables[itemIndex].Icon;
            m_consumableQuantity.text = "Quantidade no Inventário: " + PlayerData.Instance.Consumables[itemIndex].Quantity.ToString();
            m_consumableRarity.text = PlayerData.Instance.Consumables[itemIndex].ItemRarity.RarityName;
        }
    }
}