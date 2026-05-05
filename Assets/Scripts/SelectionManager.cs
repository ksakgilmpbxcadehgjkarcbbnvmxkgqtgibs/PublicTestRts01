using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    private UnitSelecting _selectUnit; // В будущем сделаем List
                                        
    private void OnEnable() => InputManager.OnButtonClick += ClickInUnit;
    private void OnDisable() => InputManager.OnButtonClick -= ClickInUnit;
    private void ClickInUnit(ClickEntity clickEntity)
    {
        if (clickEntity.button != Mouse.current.leftButton )
            return;

        if (clickEntity.raycastHit.collider.TryGetComponent(out UnitSelecting unitSelecting))
        {
            _selectUnit?.Deselect();
            unitSelecting.Select();
            _selectUnit = unitSelecting;
        }
        else
        {
            _selectUnit?.Deselect();
            _selectUnit = null;
        }
    }
}
