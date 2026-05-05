using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class ClickEntity
{
    public ButtonControl button;
    public RaycastHit raycastHit;

    public static ClickEntity CreateClick(ButtonControl button, RaycastHit raycastHit)
        => new ClickEntity
        {
            button = button,
            raycastHit = raycastHit
        };
}
