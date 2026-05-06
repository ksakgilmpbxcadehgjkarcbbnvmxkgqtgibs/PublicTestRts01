using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _unitPrefab;
    public override void InstallBindings()
    {
        BindingSpecialZenject<Image>("SelectionBox");

        BindingZenject<UiManager>();
        BindingZenject<SelectionManager>();
        Container.BindInstance(Camera.main).AsSingle();
        BindingSimpleZenject<UnitListManager>();


        BindingFactoryZenject<UnitFactory, UnitFactory.Factory,UnitLocalInstaller>(_unitPrefab, "Units");
    }

    private void BindingSimpleZenject<T>() => Container.Bind<T>().AsSingle();
    private void BindingZenject<T>() => Container.Bind<T>().FromComponentInHierarchy().AsSingle();
    private void BindingSpecialZenject<T>(string Id) => Container.Bind<T>().WithId(Id).FromComponentInHierarchy().AsSingle();
    private void BindingFactoryZenject<Tcomp, Tfactory, Tinstaller>(Object prefab,string group = "Group")
        where Tcomp : Component
        where Tfactory : PlaceholderFactory<Vector3,Quaternion,Tcomp>
        where Tinstaller : MonoInstaller
        => Container
        .BindFactory<Vector3, Quaternion, Tcomp, Tfactory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<Tinstaller>(prefab)
        .UnderTransformGroup(group);
}
