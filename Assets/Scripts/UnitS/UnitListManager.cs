using System.Collections.Generic;
using UnityEngine;

public class UnitListManager
{
    private List<GameObject> UnitsGame = new List<GameObject>();
    public List<GameObject> GetUnits() => UnitsGame;

    public void AddUnitInList(GameObject unit) => UnitsGame.Add(unit);
    public void RemoveFromList(GameObject unit) => UnitsGame.Remove(unit);

}
