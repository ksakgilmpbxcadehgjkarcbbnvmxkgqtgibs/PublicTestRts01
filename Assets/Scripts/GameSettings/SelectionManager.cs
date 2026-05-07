using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class SelectionManager : MonoBehaviour
{
    private List<UnitSelecting> _selectUnits = new List<UnitSelecting>();

    [Inject]
    private InputManager _inputManager;

    private void Start()
    {
        _inputManager.OnButtonClickObservable
            .Where(clickEntity => clickEntity.button == Mouse.current.leftButton)
            .Subscribe(ClickInUnit)
            .AddTo(this);

        _inputManager.OnGroupClickObservable
            .Subscribe(GroupClick)
            .AddTo(this);

    }

    private void ClickInUnit(ClickEntity clickEntity)
    {
        if (clickEntity.raycastHit.collider.TryGetComponent(out UnitSelecting unitSelecting))
        {
            UnSelectingGtoup();

            unitSelecting.Select();
            _selectUnits.Add(unitSelecting);
        }
        else
        {
            UnSelectingGtoup();
        }
    }

    private void GroupClick(List<UnitSelecting> masSelect)
    {
        UnSelectingGtoup();
        _selectUnits = masSelect;

        foreach (var unit in _selectUnits)
        {
            unit.Select();
        }
    }

    private void UnSelectingGtoup()
    {
        foreach (var unit in _selectUnits)
        {
            if (unit != null)
            {
                unit.Deselect();
            }
        }
        _selectUnits.Clear();
    }
}
