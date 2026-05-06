using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SelectionManager : MonoBehaviour
{
    private List<UnitSelecting> _selectUnits = new List<UnitSelecting>();

    private void OnEnable()
    {
        InputManager.OnButtonClick += ClickInUnit;
        InputManager.OnGroupClick += GroupClick;

    }
    private void OnDisable()
    {
        InputManager.OnButtonClick -= ClickInUnit;
        InputManager.OnGroupClick -= GroupClick;
    }

    private void ClickInUnit(ClickEntity clickEntity)
    {
        if (clickEntity.button != Mouse.current.leftButton)
            return;

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
