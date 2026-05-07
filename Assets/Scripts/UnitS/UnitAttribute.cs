using UniRx;
using UnityEngine;

public class UnitAttribute : MonoBehaviour
{
    [SerializeField]
    private ReactiveProperty<float> hitPoint;

    public IReadOnlyReactiveProperty<float> HitPoint => hitPoint;

    private void Start()
    {
        hitPoint.Value = 100f;
    }

    public void TakeDamage(float damage)
        => hitPoint.Value -= damage;
}
