using Zenject;

public class SpawnObjectsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GameCubesPool>().AsSingle();
    }
}
