using Pinbattlers.Player;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerInstaller", menuName = "Installers/PlayerInstaller")]
public class PlayerInstaller : ScriptableObjectInstaller<PlayerInstaller>
{
    [SerializeField] PlayerData

    public override void InstallBindings()
    {

    }
}