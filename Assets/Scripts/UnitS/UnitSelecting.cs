using UnityEngine;

public class UnitSelecting : MonoBehaviour
{
    private bool selectingMe = false;
    private UnitVisuals _unitVisuals;
    public void Select() => selectingMe = true;
    public void Deselect() => selectingMe = false;
    public bool GetSelect() => selectingMe;      
    private void Awake() => _unitVisuals = GetComponent<UnitVisuals>();
}
