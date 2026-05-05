using UnityEngine;

public class UnitSelecting : MonoBehaviour
{
    private bool selectingMe = false;
    private UnitVisuals _unitVisuals;

    private void Awake() => _unitVisuals = GetComponent<UnitVisuals>();
    public bool GetSelect() => selectingMe;
    public void Select()
    {
        selectingMe = true;
        _unitVisuals.SelectTurnOn();
    }
    public void Deselect()
    {
        selectingMe = false;
        _unitVisuals.SelectTurnOff();
    }

}
