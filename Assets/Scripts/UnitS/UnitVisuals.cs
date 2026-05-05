using UnityEngine;

public class UnitVisuals : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField]
    private GameObject _selectionCircle;

    public void ChandgeColorMovementStop()=> SetColorUnit(Color.white);

    public void ChangeColorMovement()=> SetColorUnit(Color.black);

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
        // Создаем блок свойств.
        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();

        // Читаем текущие свойства кэша
        meshRenderer.GetPropertyBlock(propBlock);

        // Обращаемся к шейдеру
        propBlock.SetColor("_BaseColor", color);

        // Применяем блок к мешу. Копия материяла не создается!
        meshRenderer.SetPropertyBlock(propBlock);
    }
       
    public void SelectTurnOn() => _selectionCircle.SetActive(true);
    public void SelectTurnOff() => _selectionCircle.SetActive(false);

}
