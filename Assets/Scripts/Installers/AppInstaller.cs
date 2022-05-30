using System.ComponentModel;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    [Header("Prefabs")]
    [SerializeField]
    ErrorView _errorViewPrefab;
    
    [SerializeField]
    DishView _dishViewPrefab;

    [Header("Scene")]
    [SerializeField]
    RequestView _requestViewScene;

    [SerializeField]
    InputViewContainer _inputViewContainer;

    [SerializeField]
    DisplayViewContainer _displayViewContainer;
    
    public override void InstallBindings()
    {
        // *** Controller Binding ***
        // UX
        Container.Bind<ViewController>().AsSingle().NonLazy();
        Container.Bind<SoundController>().AsSingle().NonLazy();

        // DATA
        Container.Bind<ApiController>().AsSingle().NonLazy();

        // *** Prefab Binding *** 
        Container.BindInstance<DishView>(_dishViewPrefab);
        Container.BindInstance<ErrorView>(_errorViewPrefab);
        Container.BindInstance<RequestView>(_requestViewScene);

        Container.BindInstance<InputViewContainer>(_inputViewContainer);
        Container.BindInstance<DisplayViewContainer>(_displayViewContainer);


        Container.BindFactory<DishView, DishView.Factory>().FromComponentInNewPrefab(_dishViewPrefab);
        Container.BindFactory<ErrorView, ErrorView.Factory>().FromComponentInNewPrefab(_errorViewPrefab);
    }
}

