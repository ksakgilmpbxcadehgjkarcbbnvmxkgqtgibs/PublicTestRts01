using System.Collections.Generic;
using UnityEngine;

public class UnitListManager
{
    private List<GameObject> UnitsGame = new List<GameObject>();
    public List<GameObject> GetUnits() => UnitsGame;

    public void AddUnitInList(GameObject unit)
    {
        UnitsGame.Add(unit);

        var attr = unit.GetComponent<UnitAttribute>();
        if (attr != null)
        {
            attr.OnDeath += RemoveFromList;
        }
    }
    public void RemoveFromList(GameObject unit, UnitAttribute attr)
    {
        attr.OnDeath -= RemoveFromList;
        UnitsGame.Remove(unit);
        unit.SetActive(false);
    }
}
