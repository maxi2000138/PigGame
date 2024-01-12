using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private Camera _mainCamera;

    public override void InstallBindings()
    {
        Container.Bind<ContainerMainCamera>().AsSingle().WithArguments(_mainCamera);
    }
}
