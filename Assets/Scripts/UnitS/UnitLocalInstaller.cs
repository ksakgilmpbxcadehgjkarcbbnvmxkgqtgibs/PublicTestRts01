using UnityEngine;
using Zenject;

public class UnitLocalInstaller : MonoInstaller
{
    [SerializeField] private GameObject _selectionCircle;

    // —юда Zenject передаст данные из фабрики
    [Inject] private Vector3 _spawnPosition;
    [Inject] private Quaternion _spawnRotation;

    public override void InstallBindings()
    {
        Container.BindInstance(_spawnPosition).AsSingle();
        Container.BindInstance(_spawnRotation).AsSingle();

        Container.BindInstance(_selectionCircle).WithId("SelectionCircle");

        BindingZenject<UnitMovementNav>();
        BindingZenject<UnitVisuals>();
        BindingZenject<UnitSelecting>();
        BindingZenject<UnitFactory>();
        BindingZenject<UnitAttribute>();

    }

    private void BindingZenject<T>() => Container.Bind<T>().FromComponentInHierarchy().AsSingle();
}
