using CodeBase.Infrastructure;
using CodeBase.Logic;
using UnityEngine;
using Zenject;

public class ProjectServicesInstaller : MonoInstaller
{
    [SerializeField] private LoadingCurtain _loadingCurtain;

    public override void InstallBindings()
    {
        Container.Bind<SceneLoaderWithCurtains>().AsSingle();
        Container.Bind<ILoadingCurtain>().FromInstance(_loadingCurtain).AsSingle();
        Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
    }
}
