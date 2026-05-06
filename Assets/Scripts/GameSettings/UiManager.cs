using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiManager : MonoBehaviour
{
    [Inject(Id = "SelectionBox")]
    private Image _selectionBox;

    private void Start()
    {
        _selectionBox.gameObject.SetActive(false);
    }

    public void SetBoardSize(float width,float hight) => 
        _selectionBox.rectTransform.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(hight));
    public void SetBoardSize(Vector2 vector2) =>
        _selectionBox.rectTransform.sizeDelta = vector2;
    public void TurnOff() => _selectionBox.gameObject.SetActive(false);
    public void TurnOn() => _selectionBox.gameObject.SetActive(true);

    public void SetBoardPosion(float minX,float minY) =>
        _selectionBox.rectTransform.anchoredPosition = new Vector2(minX, minY);

}
