using UniRx;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Zenject;

public class UnitMovementNav : MonoBehaviour
{
    private NavMeshAgent _agent;

    private Vector3? _target;

    private UnitVisuals _unitVisuals;

    private UnitSelecting _unitSelecting;

    [Inject]
    private InputManager _inputManager;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _unitVisuals = GetComponent<UnitVisuals>();
        _unitSelecting = GetComponent<UnitSelecting>();
    }
    private void Start()
    {
        _inputManager.OnButtonClickObservable
            .Where(clickEntity => clickEntity.button == Mouse.current.rightButton
            && _unitSelecting.GetSelect())
            .Subscribe(MoveToTarget)
            .AddTo(this);
    }

    public void Stop()
    {
        _agent.enabled = false;
    }

    private void MoveToTarget(ClickEntity target)
    {
        if (!_agent.isActiveAndEnabled)
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
