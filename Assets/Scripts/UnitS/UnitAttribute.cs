using System;
using UnityEngine;

public class UnitAttribute : MonoBehaviour
{
    public event Action<GameObject, UnitAttribute> OnDeath;

    [SerializeField]
    private float hitPoint = 100;

    public void TakeDamage(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            OnDeath.Invoke(gameObject,this);              
        }
    }
}
