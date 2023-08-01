using Pinbattlers.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuBlock : MonoBehaviour
{
    private enum MenuType
    {
        Grimoire,
        Inventory,
        Shop
    }

    [SerializeField] private MenuType m_menuType;

    private Button m_button;

    [Inject]
    private PlayerData m_playerData;

    private void Start()
    {
        m_button = GetComponent<Button>();

        if (m_menuType == MenuType.Grimoire)
        {
            if (m_playerData.Abilities == null) m_button.interactable = false;
        }
        else if (m_menuType == MenuType.Inventory)
        {
            if (m_playerData.Relics == null) m_button.interactable = false;
        }
        else
        {
            if (m_playerData.Points < 10000) m_button.interactable = false;
        }
    }
}