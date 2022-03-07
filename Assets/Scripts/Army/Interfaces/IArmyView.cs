using MAG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MAG.Army.View
{
    public interface IArmyView
    {
        void ArmySetup(List<ArmyEntry> entries);
        void SelectSoldier(string key);
        void SpawnSoldier(Vector3 position);
    }
}
