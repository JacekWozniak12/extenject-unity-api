using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // *** Controller Binding ***
        // UX
        Container.Bind<PopupController>().AsSingle().NonLazy();
        Container.Bind<SoundController>().AsSingle().NonLazy();

        // DATA
        Container.Bind<ApiController>().AsSingle().NonLazy();

    }
}

