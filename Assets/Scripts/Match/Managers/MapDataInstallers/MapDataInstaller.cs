using Pinbattlers.Menus;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MapDataInstaller", menuName = "Installers/MapDataInstaller")]
public class MapDataInstaller : ScriptableObjectInstaller<MapDataInstaller>
{
    [SerializeField] private MapsData m_mapData;

    public override void InstallBindings()
    {
        Container.Bind<MapsData>().FromInstance(m_mapData).AsSingle();
    }
}