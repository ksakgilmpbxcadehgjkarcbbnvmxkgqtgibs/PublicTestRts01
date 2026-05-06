using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class UnitSpawner : MonoBehaviour
{
    [Inject]
    private UnitFabrica.Factory _unitFactory;

    [Inject]
    private UnitListManager _unitListManager;

    private float _cooldownTimer = 1f;
    private float _nextSpawnTime = 0;

    private void OnEnable() => InputManager.OnButtonClick += SpawnUnit;
    private void OnDisable() => InputManager.OnButtonClick -= SpawnUnit;

    private void SpawnUnit(ClickEntity clickEntity)
    {
        if (Time.time < _nextSpawnTime)
            return;

        if (clickEntity.button != Keyboard.current.spaceKey) 
            return;

        // ≈сли игрок тыкает вне игрово пол€ ... как то
        if (clickEntity.raycastHit.collider == null)
            return;

        _nextSpawnTime = _cooldownTimer + Time.time;
         var unitCreate = _unitFactory.Create(clickEntity.raycastHit.point, Quaternion.identity);

        _unitListManager.AddUnitInList(unitCreate.gameObject);
    }
}
