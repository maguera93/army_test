using MAG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MAG.Army.HUD
{
    public interface IArmyHUD
    {
        event SelectSoldierEvent OnSelectSoldier;

        void SelectSoldier(string key);
        void Setup(List<ArmyEntry> entries);
        void SpawnSoldier(Vector3 position);
    }
}
