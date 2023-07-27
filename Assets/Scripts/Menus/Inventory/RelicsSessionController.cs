using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pinbattlers.Menus
{
    public class RelicsSessionController : MonoBehaviour, IInfoUpdatable
    {
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
            if (m_content.childCount == PlayerData.Instance.Relics.Count) return;

            for (int i = m_content.childCount; i < PlayerData.Instance.Relics.Count; i++)
            {
                m_itemInstance = Instantiate(m_itemInstance, m_content);
                m_itemInstance.FillContent(i, this);
            }

            UpdateInfo(0);
        }

        public void UpdateInfo(int itemIndex)
        {
            m_itemInspectedIndex = itemIndex;

            m_relicName.text = PlayerData.Instance.Relics[itemIndex].Name;
            m_relicLoreDescription.text = PlayerData.Instance.Relics[itemIndex].LoreDescription;
            m_relicMechanicDescription.text = PlayerData.Instance.Relics[itemIndex].MechanicDescription;
            m_relicIllustration.sprite = PlayerData.Instance.Relics[itemIndex].Icon;

            if (PlayerData.Instance.Relics[itemIndex] == PlayerData.Instance.RelicEquiped) m_equipButton.interactable = false;
            else m_equipButton.interactable = true;
        }

        public void Equip()
        {
            PlayerData.Instance.EquipRelic(PlayerData.Instance.Relics[m_itemInspectedIndex]);
            m_equipButton.interactable = false;
        }
    }
}