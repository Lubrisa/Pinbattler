using Pinbattlers.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseRewardController : MonoBehaviour
{
    public abstract TMP_Text m_rewardName { get; protected set; }
    public abstract TMP_Text m_rewardDescription { get; protected set; }
    public abstract Image m_rewardIllustration { get; protected set; }

    public abstract void SetInfo(GameOverMenuController controller);
}