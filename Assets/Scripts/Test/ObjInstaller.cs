using Zenject;

public class ObjInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<RandomTest>().AsSingle();
    }
}