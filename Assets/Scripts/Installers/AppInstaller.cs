using UnityEngine.UIElements;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    [Header("Scene")]
    [SerializeField]
    MainUI _mainUI;

    [Header("UXML")]
    [SerializeField]
    VisualTreeAsset _errorViewUXML;

    [SerializeField]
    VisualTreeAsset _dishViewUXML;

    [SerializeField]
    VisualTreeAsset _requestViewUXML;

    public override void InstallBindings()
    {
        // *** Controller Binding ***
        // UX
        Container.Bind<ViewController>().AsSingle().NonLazy();
        Container.Bind<SoundController>().AsSingle().NonLazy();

        // DATA
        Container.Bind<ApiController>().AsSingle().NonLazy();
        Container.Bind<InputController>().AsSingle().NonLazy();
        Container.Bind<FoodTypeController>().AsSingle().NonLazy();

        // *** Prefab Binding *** 
        Container.BindInstance<MainUI>(_mainUI);

        // Container.BindInstance<ErrorView>(_errorViewUXML);
        // Container.BindInstance<RequestView>(_requestViewUXML);


        // Container.BindFactory<DishView, DishView.Factory>().FromComponentInNewPrefab(_dishViewPrefab);
        // Container.BindFactory<ErrorView, ErrorView.Factory>().FromComponentInNewPrefab(_errorViewPrefab);
    }
}

