using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _unitPrefab;

    [SerializeField]
    private float _spawnRadius = 1f;

    private float _cooldownTimer = 5f;
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
        Instantiate(_unitPrefab, clickEntity.raycastHit.point, Quaternion.identity);
    }
}
