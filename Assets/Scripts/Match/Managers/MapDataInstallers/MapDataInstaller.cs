using Pinbattlers.Menus;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MapDataInstaller", menuName = "Installers/MapDataInstaller")]
public class MapDataInstaller : ScriptableObjectInstaller<MapDataInstaller>
{
    [SerializeField] private MapData m_mapData;

    public override void InstallBindings()
    {
        Container.Bind<MapData>().FromInstance(m_mapData).AsSingle();
    }
}