using UniRx;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using System;

public class UnitAttribute : MonoBehaviour
{
    [SerializeField]
    private ReactiveProperty<float> hitPoint;

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
        hitPoint.Value = 100f;

        hitPoint.Where(hp => hp <= 0)
            .Take(1)
            .Subscribe( _=> 
            { 
                DieAsync().Forget(); 
            })
            .AddTo(this);
    }

    public void TakeDamage(float damage)
        => hitPoint.Value -= damage;

    public async UniTask DieAsync() 
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
        gameObject.SetActive(false);

    }

}
