using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _constrPrefab;
//    private void OnEnable() => InputManager.OnLeftClicked += OnBuildConstruction;
//    private void OnDisable() => InputManager.OnLeftClicked -= OnBuildConstruction;

    private void OnBuildConstruction(Vector3 newTarget)
    {
        Instantiate(_constrPrefab, newTarget, Quaternion.identity);
    }
}
