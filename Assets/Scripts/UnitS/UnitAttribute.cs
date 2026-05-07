using System;
using UniRx;
using UnityEngine;
using Zenject;

public class UnitAttribute : MonoBehaviour
{
    [SerializeField]
    private ReactiveProperty<float> hitPoint;

    [Inject]
    private UnitListManager _unitListManager;

    private void Start()
    {
        hitPoint.Value = 100f;

        hitPoint.Where(hp => hp <= 0)
            .Take(1)
            .Subscribe(Die)
            .AddTo(this);
    }

    public void TakeDamage(float damage)
        => hitPoint.Value -= damage;

    public void Die(float damage) 
    {
        _unitListManager.RemoveFromList(gameObject);
        Destroy(gameObject);
    }

}
