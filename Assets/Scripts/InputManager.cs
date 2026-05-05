using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    public static event Action<ClickEntity> OnBittonClick;

    private Camera _mainCamera;
    private void Awake() => _mainCamera = Camera.main;
    private void Update()
    {
        if (Mouse.current != null)
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
                CreateCliclInvoke(Mouse.current.rightButton);

            if (Mouse.current.leftButton.wasPressedThisFrame)
                CreateCliclInvoke(Mouse.current.leftButton);
        }
        if (Keyboard.current != null)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
                CreateCliclInvoke(Keyboard.current.spaceKey);
        }
    }
    private void CreateCliclInvoke(ButtonControl buttonControl)
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        var ray = _mainCamera.ScreenPointToRay(mousePosition); 

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var click = ClickEntity.CreateClick(buttonControl, hit);
            OnBittonClick.Invoke(click);
        }
    }
}
