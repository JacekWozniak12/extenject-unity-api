using UnityEngine.UIElements;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    [Header("Scene")]
    [SerializeField]
    MainUI _mainUI;

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

        // *** UXML Binding *** 
        Container.Bind<DishView>().AsSingle().WithArguments<VisualTreeAsset>(_dishViewUXML);
        Container.Bind<ErrorView>().AsSingle().WithArguments<VisualTreeAsset>(_errorViewUXML);
        Container.Bind<RequestView>().AsSingle().WithArguments<VisualTreeAsset>(_requestViewUXML);

        Container.BindIFactory<VisualTreeAsset, RequestView, RequestView.Factory>().AsSingle();

        Container.BindInstance<MainUI>(_mainUI);
    }
}

