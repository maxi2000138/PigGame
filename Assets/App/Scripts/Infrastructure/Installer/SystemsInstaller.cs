using UnityEngine;
using Zenject;

public class SystemsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UpdateSystemGroup>().AsSingle();
        Container.Bind<FixedUpdateSystemGroup>().AsSingle();
    }
}
