using Zenject;

public class SpawnObjectsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameCubesSpawner>().AsSingle();
        Container.BindInterfacesAndSelfTo<PigSpawner>().AsSingle();
    }
}
