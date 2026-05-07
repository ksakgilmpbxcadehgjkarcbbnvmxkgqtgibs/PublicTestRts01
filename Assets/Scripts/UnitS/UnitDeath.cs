using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;
using UniRx;

public class UnitDeath : MonoBehaviour
{
    [Inject]
    private UnitAttribute _unitAttribute;

    [Inject]
    private UnitListManager _unitListManager;

    [Inject]
    private UnitSelecting _unitSelecting;

    [Inject]
    private UnitMovementNav _unitMovementNav;

    [Inject]
    private UnitVisuals _unitVisuals;

    private void Start()
    {
        _unitAttribute.HitPoint.Where(hp => hp <= 0)
        .Take(1)
        .Subscribe(_ =>
        {
            DieAsync().Forget();
        })
        .AddTo(this);
    }

    private async UniTask DieAsync()
    {
        _unitListManager.RemoveFromList(gameObject);

        _unitMovementNav.Stop();
        _unitVisuals.ChandgeColorMovementDead();

        _unitMovementNav.enabled = false;
        _unitSelecting.enabled = false;
        _unitVisuals.enabled = false;

        await UniTask.Delay(TimeSpan.FromSeconds(2),
            cancellationToken: this.GetCancellationTokenOnDestroy());

        Destroy(gameObject);
    }
}
