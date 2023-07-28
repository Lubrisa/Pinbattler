using Pinbattlers.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyRewardController : BaseRewardController
{
    private enum CurrencyType
    {
        Points,
        Stars,
        Essences
    }

    [field: SerializeField] public override TMP_Text m_rewardName { get; protected set; }
    [field: SerializeField] public override TMP_Text m_rewardDescription { get; protected set; }
    [field: SerializeField] public override Image m_rewardIllustration { get; protected set; }

    [SerializeField] private Sprite m_rewardSprite;

    [SerializeField] private CurrencyType m_currencyType;

    public override void SetInfo(GameOverMenuController controller)
    {
        if (m_currencyType == CurrencyType.Points)
        {
            m_rewardName.text = "Pontos";
            m_rewardDescription.text = controller.Score.ToString();
        }
        else if (m_currencyType == CurrencyType.Stars)
        {
            m_rewardName.text = "Estrela";
            m_rewardDescription.text = controller.Stars.ToString();
        }
        else
        {
            m_rewardName.text = "Essências";
            m_rewardDescription.text = controller.Essences.ToString();
        }
    }
}