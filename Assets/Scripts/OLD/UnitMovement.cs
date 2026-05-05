using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    private Vector3 _targetPositoin;
    private bool _isMoving = false;

    // Вызывается каждый раз, когда мы создаем объект на сцене
 //   private void OnEnable() => InputManager.OnRightClicked += MoveToTarget;

    // Вызывается каждый раз, когда мы удаляем объект со сцены
    // Авто отписывания нету, надо вручную отписываться от событий
 //   private void OnDisable() => InputManager.OnRightClicked -= MoveToTarget;

    private void MoveToTarget(Vector3 newTarget)
    {
        _targetPositoin = newTarget;
        _targetPositoin.y = transform.position.y;
        _isMoving = true;
    }
    void Update()
    {
        if (!_isMoving) return;

        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _targetPositoin, step);

        if (Vector3.Distance(transform.position, _targetPositoin) < 0.05f)
        {
            _isMoving = false;
        }
    }
}
