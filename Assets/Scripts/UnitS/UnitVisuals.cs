using UnityEngine;

public class UnitVisuals : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public void ChandgeColorMovementStop()=> SetColorUnit(Color.white);

    public void ChandgeColorMovement()=> SetColorUnit(Color.black);

    private void Start()
    {
        var rndColor = Random.ColorHSV();

        meshRenderer = GetComponent<MeshRenderer>();

        SetColorUnit(rndColor);
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
}
