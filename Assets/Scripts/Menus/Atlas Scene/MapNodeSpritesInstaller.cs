using UnityEngine;
using Zenject;

public class MapNodeSpritesInstaller : MonoInstaller<MapNodeSpritesInstaller>
{
    [SerializeField] private Sprite[] m_mapNodeSprites;

    public override void InstallBindings()
    {
        Container.Bind<Sprite[]>().FromInstance(m_mapNodeSprites).AsSingle();
    }
}