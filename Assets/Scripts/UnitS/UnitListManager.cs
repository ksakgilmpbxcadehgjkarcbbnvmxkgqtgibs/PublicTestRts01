using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UnitListManager : MonoBehaviour
{
    private List<GameObject> UnitsGame = new List<GameObject>();
    public List<GameObject> GetUnits() => UnitsGame;

    private void OnEnable() => UnitSpawner.OnSpawnUnit += AddUnitInList;
    private void OnDisable() => UnitSpawner.OnSpawnUnit -= AddUnitInList;

    private void AddUnitInList(GameObject unit)
    {
        UnitsGame.Add(unit);

        var attr = unit.GetComponent<UnitAttribute>();
        if (attr != null)
        {
            attr.OnDeath += RemoveFromList;
        }
    }
    public void RemoveFromList(GameObject unit)
    {
        var attr = unit.GetComponent<UnitAttribute>();
        if (attr != null)
        {
            attr.OnDeath -= RemoveFromList;
        }
        UnitsGame.Remove(unit);
        unit.SetActive(false);
        Destroy(unit);
    }
}
