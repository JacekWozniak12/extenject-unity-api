using UnityEngine.UIElements;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    [SerializeField]
    VisualTreeAsset _mainUXML, _errorViewUXML, _dishViewUXML, _requestViewUXML;

    [SerializeField]
    PanelSettings _panelSettings;

    public override void InstallBindings()
    {
        // MAIN UI
        Container.Bind<MainUI>().
            FromNewComponentOnNewGameObject().
            WithGameObjectName("Main UI").
            AsSingle().
            WithArguments<VisualTreeAsset, PanelSettings>(_mainUXML, _panelSettings);

        // UX ELEMENTS
        Container.BindFactory<Dish, DishView, DishView.Factory>().WithArguments<VisualTreeAsset>(_dishViewUXML);
        Container.BindFactory<string, ErrorView, ErrorView.Factory>().WithArguments<VisualTreeAsset>(_errorViewUXML);
        Container.BindFactory<RequestView, RequestView.Factory>().WithArguments<VisualTreeAsset>(_requestViewUXML);

        // *** Controller Binding ***
        // UX
        Container.BindInterfacesAndSelfTo<ViewController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<SoundController>().AsSingle().NonLazy();

        // DATA
        Container.BindInterfacesAndSelfTo<ApiController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<FoodTypeController>().AsSingle().NonLazy();

    }
}


