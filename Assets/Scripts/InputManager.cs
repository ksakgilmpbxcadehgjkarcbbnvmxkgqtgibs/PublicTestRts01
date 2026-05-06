using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    public static event Action<ClickEntity> OnButtonClick;
    public static event Action<List<UnitSelecting>> OnGroupClick;

    [SerializeField]
    private UiManager _uiManager;

    [SerializeField]
    private UnitListManager _unitListManager;

    private Camera _mainCamera;

    private Vector2 _positionMouseInWorld;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        if (Mouse.current != null)
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
                CreateClickInvoke(Mouse.current.rightButton);

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                _positionMouseInWorld = Mouse.current.position.ReadValue();
            }

            if (Mouse.current.leftButton.isPressed)
            {
                Vector2 _endPosionMouseInWorld = Mouse.current.position.ReadValue();

                float minX = Mathf.Min(_positionMouseInWorld.x, _endPosionMouseInWorld.x);
                float minY = Mathf.Min(_positionMouseInWorld.y, _endPosionMouseInWorld.y);
                float maxX = Mathf.Max(_positionMouseInWorld.x, _endPosionMouseInWorld.x);
                float maxY = Mathf.Max(_positionMouseInWorld.y, _endPosionMouseInWorld.y);

                _uiManager.SetBoardSize(maxX - minX, maxY - minY);
                _uiManager.SetBoardPosion(minX, minY);

                _uiManager.TurnOn();
            }

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                Vector2 _endPosionMouseInWorld = Mouse.current.position.ReadValue();

                if (!VectorHelper.IsSameVector(_endPosionMouseInWorld, _positionMouseInWorld)) 
                {                  
                    var masUnit = _unitListManager.GetUnits();

                    var masSelecting = masUnit.Where(
                        x => VectorHelper.IsUnitRec(_mainCamera.WorldToScreenPoint(x.transform.position),
                        _positionMouseInWorld, 
                        _endPosionMouseInWorld))
                        .ToList();
                
                    OnGroupClick.Invoke(masSelecting);

                    _uiManager.TurnOff();
                    _uiManager.SetBoardSize(Vector2.zero);
                }
                else
                {
                    CreateClickInvoke(Mouse.current.leftButton);
                }
            }
        }
        if (Keyboard.current != null)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
                CreateClickInvoke(Keyboard.current.spaceKey);
        }
    }
    private void CreateClickInvoke(ButtonControl buttonControl)
    {
        Ray ray = GetRayFromMouse();

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var click = ClickEntity.CreateClick(buttonControl, hit);
            OnButtonClick.Invoke(click);
        }
    }

    private Ray GetRayFromMouse()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        var ray = _mainCamera.ScreenPointToRay(mousePosition);
        return ray;
    }
}
