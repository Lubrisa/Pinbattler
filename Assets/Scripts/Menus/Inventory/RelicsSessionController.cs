using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class RelicsSessionController : MonoBehaviour, IInfoUpdatable
    {
        [Inject]
        private PlayerData m_playerData;

        private Transform m_content;
        private TMP_Text m_relicName;
        private TMP_Text m_relicLoreDescription;
        private TMP_Text m_relicMechanicDescription;
        private Image m_relicIllustration;
        private Button m_equipButton;

        [SerializeField] private ItemFill m_itemInstance;
        private int m_itemInspectedIndex;

        [Inject]
        private void Constructor(
            [Inject(Id = "RelicsContent")] RectTransform content,
            [Inject(Id = "RelicName")] TextMeshProUGUI relicName,
            [Inject(Id = "RelicLore")] TextMeshProUGUI relicLore,
            [Inject(Id = "RelicMechanic")] TextMeshProUGUI relicMechanic,
            [Inject(Id = "RelicIcon")] Image relicIllustration,
            [Inject(Id = "RelicEquip")] Button equipButton)
        {
            m_content = content;
            m_relicName = relicName;
            m_relicLoreDescription = relicLore;
            m_relicMechanicDescription = relicMechanic;
            m_relicIllustration = relicIllustration;
            m_equipButton = equipButton;
        }

        public void FillContent()
        {
            if (m_content.childCount == m_playerData.Relics.Count) return;

            for (int i = m_content.childCount; i < m_playerData.Relics.Count; i++)
            {
                m_itemInstance = Instantiate(m_itemInstance, m_content);
                m_itemInstance.FillContent(i, this, m_playerData);
            }
        }

        public void UpdateInfo(int itemIndex)
        {
            m_itemInspectedIndex = itemIndex;

            m_relicName.text = m_playerData.Relics[itemIndex].Name;
            m_relicLoreDescription.text = m_playerData.Relics[itemIndex].LoreDescription;
            m_relicMechanicDescription.text = m_playerData.Relics[itemIndex].MechanicDescription;
            m_relicIllustration.sprite = m_playerData.Relics[itemIndex].IconSprite.IconSprite;

            if (m_playerData.Relics[itemIndex] == m_playerData.RelicEquiped) m_equipButton.interactable = false;
            else m_equipButton.interactable = true;
        }

        public void Equip()
        {
            m_playerData.EquipRelic(m_playerData.Relics[m_itemInspectedIndex]);
            m_equipButton.interactable = false;
        }
    }
}