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
        private PlayerData m_instance;

        [SerializeField] private Transform m_content;

        [SerializeField] private TMP_Text m_relicName;
        [SerializeField] private TMP_Text m_relicLoreDescription;
        [SerializeField] private TMP_Text m_relicMechanicDescription;
        [SerializeField] private Image m_relicIllustration;
        [SerializeField] private Button m_equipButton;

        [SerializeField] private ItemFill m_itemInstance;
        private int m_itemInspectedIndex;

        public void FillContent()
        {
            if (m_content.childCount == m_instance.Relics.Count) return;

            for (int i = m_content.childCount; i < m_instance.Relics.Count; i++)
            {
                m_itemInstance = Instantiate(m_itemInstance, m_content);
                m_itemInstance.FillContent(i, this, m_instance);
            }

            UpdateInfo(0);
        }

        public void UpdateInfo(int itemIndex)
        {
            m_itemInspectedIndex = itemIndex;

            m_relicName.text = m_instance.Relics[itemIndex].Name;
            m_relicLoreDescription.text = m_instance.Relics[itemIndex].LoreDescription;
            m_relicMechanicDescription.text = m_instance.Relics[itemIndex].MechanicDescription;
            m_relicIllustration.sprite = m_instance.Relics[itemIndex].IconSprite.IconSprite;

            if (m_instance.Relics[itemIndex] == m_instance.RelicEquiped) m_equipButton.interactable = false;
            else m_equipButton.interactable = true;
        }

        public void Equip()
        {
            m_instance.EquipRelic(m_instance.Relics[m_itemInspectedIndex]);
            m_equipButton.interactable = false;
        }
    }
}