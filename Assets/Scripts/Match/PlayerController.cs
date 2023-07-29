using Pinbattlers.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject]
    private PlayerData m_playerData;

    [field: SerializeField] public int Life { get; set; }
    private int m_attack;
    private int m_defense;

    private Sprite m_skin;

    private void Start()
    {
        Life = m_playerData.Life + m_playerData.LifeModifier;
        m_attack = m_playerData.Attack + m_playerData.AttackModifier;
        m_defense = m_playerData.Defense;
        m_skin = m_playerData.SkinEquiped;
    }

    private void Update()
    {
    }
}