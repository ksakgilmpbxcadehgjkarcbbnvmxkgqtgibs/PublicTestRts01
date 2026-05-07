using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Zenject;

public class InputManager : MonoBehaviour
{
    private Subject<ClickEntity> OnButtonClick = new Subject<ClickEntity>();
    public IObservable<ClickEntity> OnButtonClickObservable => OnButtonClick;

    private Subject<List<UnitSelecting>> OnGroupClick = new Subject<List<UnitSelecting>>();
    public IObservable<List<UnitSelecting>> OnGroupClickObservable => OnGroupClick;

    private List<UnitSelecting> masTempSelect = new List<UnitSelecting>();

    [Inject]
    private UiManager _uiManager;

    [Inject]
    private UnitListManager _unitListManager;

    [Inject]
    private Camera _mainCamera;

    private Vector2 _positionMouseInWorld;

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

                    masTempSelect = masUnit
                        .Where(
                        x => VectorHelper.IsUnitRec(_mainCamera.WorldToScreenPoint(x.transform.position),
                        _positionMouseInWorld,
                        _endPosionMouseInWorld))
                        .Select(x => x.GetComponent<UnitSelecting>())
                        .ToList();

                    OnGroupClick.OnNext(masTempSelect);

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

            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                masTempSelect
                    .Select(x => x.GetComponent<UnitAttribute>())
                    .ToList()
                    .ForEach(x=>x.TakeDamage(50));
            }
        }
    }
    private void CreateClickInvoke(ButtonControl buttonControl)
    {
        Ray ray = GetRayFromMouse();

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var click = ClickEntity.CreateClick(buttonControl, hit);
            OnButtonClick.OnNext(click);
        }
    }

    private Ray GetRayFromMouse()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        var ray = _mainCamera.ScreenPointToRay(mousePosition);
        return ray;
    }
}
