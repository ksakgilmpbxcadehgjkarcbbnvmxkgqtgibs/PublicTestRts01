using UnityEngine;
using Zenject;

public class UnitVisuals : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [Inject(Id = "SelectionCircle")]
    private GameObject _selectionCircle;

    public void ChandgeColorMovementStop()=> SetColorUnit(Color.white);
    public void ChangeColorMovement()=> SetColorUnit(Color.black);
    public void ChandgeColorMovementDead() => SetColorUnit(Color.darkRed);

    private void Start()
    {
        var rndColor = Random.ColorHSV();

        meshRenderer = GetComponent<MeshRenderer>();

        SetColorUnit(rndColor);

        _selectionCircle.SetActive(false);

        SelectTurnOff();
    }

    private void SetColorUnit(Color color)
    {
        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
        meshRenderer.GetPropertyBlock(propBlock);
        propBlock.SetColor("_BaseColor", color);
        meshRenderer.SetPropertyBlock(propBlock);
    }
       
    public void SelectTurnOn() => _selectionCircle.SetActive(true);
    public void SelectTurnOff() => _selectionCircle.SetActive(false);

}
