using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class UnitMovementNav : MonoBehaviour
{
    private NavMeshAgent _agent;

    private Vector3? _target;

    private UnitVisuals _unitVisuals;

    private UnitSelecting _unitSelecting;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _unitVisuals = GetComponent<UnitVisuals>();
        _unitSelecting = GetComponent<UnitSelecting>();
    }

    private void OnEnable() => InputManager.OnButtonClick += MoveToTarget;
    private void OnDisable() => InputManager.OnButtonClick -= MoveToTarget;

    private void MoveToTarget(ClickEntity target)
    {
        if (target.button != Mouse.current.rightButton)
            return;

        if (!_unitSelecting.GetSelect())
            return;

        _agent.SetDestination(target.raycastHit.point);
        _target = target.raycastHit.point;

        _unitVisuals.ChangeColorMovement();
    }
    private void Update()
    {
        if (!_agent.isOnNavMesh)
            return;

        if (_target == null)
            return;

        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            _unitVisuals.ChandgeColorMovementStop();
            _target = null;
        }
    }
}
