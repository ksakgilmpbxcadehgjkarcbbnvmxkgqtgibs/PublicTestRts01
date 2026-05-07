using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _unitPrefab;
    public override void InstallBindings()
    {
        BindById<Image>("SelectionBox");

        BindComponent<UiManager>();
        BindComponent<SelectionManager>();
        BindComponent<InputManager>();

        Container.BindInstance(Camera.main).AsSingle();

        Binding<UnitListManager>();


        BindingFactory<UnitFactory, UnitFactory.Factory,UnitLocalInstaller>(_unitPrefab, "Units");
    }
    private void Binding<T>() => Container.Bind<T>().AsSingle();
    private void BindComponent<T>() => Container.Bind<T>().FromComponentInHierarchy().AsSingle();
    private void BindById<T>(string Id) => Container.Bind<T>().WithId(Id).FromComponentInHierarchy().AsSingle();
    private void BindingFactory<Tcomp, Tfactory, Tinstaller>(Object prefab,string group = "Group")
        where Tcomp : Component
        where Tfactory : PlaceholderFactory<Vector3,Quaternion,Tcomp>
        where Tinstaller : MonoInstaller
        => Container
        .BindFactory<Vector3, Quaternion, Tcomp, Tfactory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<Tinstaller>(prefab)
        .UnderTransformGroup(group);
}
