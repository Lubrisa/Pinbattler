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
        private PlayerData m_playerData;

        private Transform m_content;
        private TMP_Text m_consumableName;
        private TMP_Text m_consumableLoreDescription;
        private TMP_Text m_consumableMechanicDescription;
        private Image m_consumableIllustration;
        private TMP_Text m_consumableQuantity;
        private TMP_Text m_consumableRarity;

        [SerializeField] private ItemFill m_itemInstance;

        [Inject]
        private void Constructor(
            [Inject(Id = "ConsumablesContent")] RectTransform content,
            [Inject(Id = "ConsumableName")] TextMeshProUGUI consumableName,
            [Inject(Id = "ConsumableLore")] TextMeshProUGUI consumableLore,
            [Inject(Id = "ConsumableMechanic")] TextMeshProUGUI consumableMechanic,
            [Inject(Id = "ConsumableIcon")] Image consumableIllustration,
            [Inject(Id = "ConsumableQuantity")] TextMeshProUGUI consumableQuantity,
            [Inject(Id = "ConsumableRarity")] TextMeshProUGUI consumableRarity)
        {
            m_content = content;
            m_consumableName = consumableName;
            m_consumableLoreDescription = consumableLore;
            m_consumableMechanicDescription = consumableMechanic;
            m_consumableIllustration = consumableIllustration;
            m_consumableQuantity = consumableQuantity;
            m_consumableRarity = consumableRarity;
        }

        public void FillContent()
        {
            if (m_content.childCount == m_playerData.Consumables.Count) return;

            for (int i = m_content.childCount; i < m_playerData.Consumables.Count; i++)
            {
                m_itemInstance = Instantiate(m_itemInstance, m_content);
                m_itemInstance.FillContent(i, this, m_playerData);
            }
        }

        public void UpdateInfo(int itemIndex)
        {
            m_consumableName.text = m_playerData.Consumables[itemIndex].Name;
            m_consumableLoreDescription.text = m_playerData.Consumables[itemIndex].LoreDescription;
            m_consumableMechanicDescription.text = m_playerData.Consumables[itemIndex].MechanicDescription;
            m_consumableIllustration.sprite = m_playerData.Consumables[itemIndex].IconSprite;
            m_consumableQuantity.text = "Quantidade no Inventário: " + m_playerData.Consumables[itemIndex].Quantity.ToString();
            m_consumableRarity.text = m_playerData.Consumables[itemIndex].ItemRarity.RarityName;
        }
    }
}