using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class UnitSpawner : MonoBehaviour
{
    [Inject]
    private UnitFactory.Factory _unitFactory;

    [Inject]
    private UnitListManager _unitListManager;

    [Inject]
    private InputManager _inputManager;

    private float _cooldownTimer = 1f;
    private float _nextSpawnTime = 0;

    private void Start()
    {
        _inputManager
            .OnButtonClickObservable
            .Where(clickEntity =>clickEntity.button == Keyboard.current.spaceKey 
            && Time.time > _nextSpawnTime 
            && clickEntity.raycastHit.collider != null)// ≈сли игрок тыкает вне игрово пол€ ... как то
            .Subscribe(SpawnUnit)
            .AddTo(this);
    }

    private void SpawnUnit(ClickEntity clickEntity)
    {
        _nextSpawnTime = _cooldownTimer + Time.time;
         var unitCreate = _unitFactory.Create(clickEntity.raycastHit.point, Quaternion.identity);
        _unitListManager.AddUnitInList(unitCreate.gameObject);
    }
}
