using Pinbattlers.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemRewardController : BaseRewardController
{
    public enum ItemType
    {
        Ability,
        Relic,
        Consumable
    }

    [field: SerializeField] public override TMP_Text m_rewardName { get; protected set; }
    [field: SerializeField] public override TMP_Text m_rewardDescription { get; protected set; }
    [field: SerializeField] public override Image m_rewardIllustration { get; protected set; }

    [field: SerializeField] public ItemType m_itemType { get; protected set; }

    public override void SetInfo(GameOverMenuController controller)
    {
        if (m_itemType == ItemType.Ability)
        {
            m_rewardName.text = controller.Ability.Name;
            m_rewardIllustration.sprite = controller.Ability.IconSprite.IconSprite;
        }
        else if (m_itemType == ItemType.Relic)
        {
            m_rewardName.text = controller.Relics[controller.RelicIndex].Name;
            m_rewardIllustration.sprite = controller.Relics[controller.RelicIndex].IconSprite.IconSprite;
            m_rewardDescription.text = controller.Relics[controller.RelicIndex].ItemRarity.RarityName;
        }
        else
        {
            m_rewardName.text = controller.Consumables[controller.ConsumableIndex].Name;
            m_rewardIllustration.sprite = controller.Consumables[controller.ConsumableIndex].IconSprite.IconSprite;
            m_rewardDescription.text = controller.Consumables[controller.ConsumableIndex].Quantity.ToString();
        }
    }
}