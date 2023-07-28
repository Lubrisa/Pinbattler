using Pinbattlers.Player;
using UnityEngine;
using Zenject;

public class PlayerDataInstaller : MonoInstaller
{
    [SerializeField] private PlayerData m_playerData;

    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(m_playerData).AsSingle();
    }
}