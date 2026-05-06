using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _unitPrefab;

    private float _cooldownTimer = 1f;
    private float _nextSpawnTime = 0;

    private void OnEnable() => InputManager.OnButtonClick += SpawnUnit;
    private void OnDisable() => InputManager.OnButtonClick -= SpawnUnit;

    public static event Action<UnitSelecting> OnSpawnUnit;

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
        var unit = Instantiate(_unitPrefab, clickEntity.raycastHit.point, Quaternion.identity);

        OnSpawnUnit.Invoke(unit.GetComponent<UnitSelecting>());
    }
}
