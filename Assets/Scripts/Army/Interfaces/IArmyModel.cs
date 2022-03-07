using System.Collections.Generic;
using UnityEngine;
using MAG.Core;

public delegate void SpawnSoldierEvent(Vector3 position);
public delegate void SelectSoldierEvent(string key);
public delegate void SetupEvent(List<ArmyEntry> entries);

namespace MAG.Army.Model
{
    public interface IArmyModel
    {
        event SpawnSoldierEvent OnSpawnSoldier;
        event SelectSoldierEvent OnSelectSoldier;
        event SetupEvent OnSetup;

        void OnSpawnSoldierRaise(Vector3 position);
        void OnSelectSoldierRaise(string key);
        void Setup(List<ArmyEntry> entries);
    }
}
