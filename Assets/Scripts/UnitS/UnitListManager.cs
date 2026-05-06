using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UnitListManager : MonoBehaviour
{
    private List<UnitSelecting> UnitsGame = new List<UnitSelecting>();
    public List<UnitSelecting> GetUnits() => UnitsGame;

    private void OnEnable() => UnitSpawner.OnSpawnUnit += AddUnitInList;
    private void OnDisable() => UnitSpawner.OnSpawnUnit -= AddUnitInList;

    private void AddUnitInList(UnitSelecting unit)
    {
        UnitsGame.Add(unit);
    }
}
