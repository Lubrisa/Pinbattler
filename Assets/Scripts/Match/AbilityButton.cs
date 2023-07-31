using Pinbattlers.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AbilityButton : MonoBehaviour
{
    [Inject]
    private PlayerData m_instance;

    private void Start()
    {
        Button button = GetComponent<Button>();

        if (m_instance.AbilityEquiped == null) button.interactable = false;
        else button.image.sprite = m_instance.AbilityEquiped.IconSprite.IconSprite;
    }

    public void OnAbilityButtonClicked()
    {
        m_instance.AbilityEquiped.Cast();
    }
}