using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    [SerializeField]
    ErrorView _errorViewPrefab;
    
    [SerializeField]
    DishView _dishViewPrefab;
    
    public override void InstallBindings()
    {
        // *** Controller Binding ***
        // UX
        Container.Bind<ViewController>().AsSingle().NonLazy();
        Container.Bind<SoundController>().AsSingle().NonLazy();

        // DATA
        Container.Bind<ApiController>().AsSingle().NonLazy();

        // *** Prefab Binding *** 
        Container.Bind<DishView>().FromComponentInNewPrefab(_dishViewPrefab);
        Container.Bind<ErrorView>().FromComponentInNewPrefab(_errorViewPrefab);
    }
}

