using UnityEngine.UIElements;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    [SerializeField]
    MainUI _mainUI;

    [SerializeField]
    VisualTreeAsset _errorViewUXML, _dishViewUXML, _requestViewUXML;

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

        // *** UXML Binding *** 
        Container.Bind<DishView>().AsTransient().WithArguments<VisualTreeAsset>(_dishViewUXML);
        Container.Bind<ErrorView>().AsTransient().WithArguments<VisualTreeAsset>(_errorViewUXML);
        Container.Bind<RequestView>().AsTransient().WithArguments<VisualTreeAsset>(_requestViewUXML);

        Container.BindFactory<Dish, DishView, DishView.Factory>();
        Container.BindFactory<string, ErrorView, ErrorView.Factory>();
        Container.BindFactory<RequestView, RequestView.Factory>();

        Container.Bind<MainUI>().FromComponentInNewPrefab(_mainUI).AsSingle();
    }
}


