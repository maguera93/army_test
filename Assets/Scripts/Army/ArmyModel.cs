using System.Collections;
using System.Collections.Generic;
using MAG.Core;
using UnityEngine;

namespace MAG.Army.Model
{
    public class ArmyModel : IArmyModel
    {
        public event SpawnSoldierEvent OnSpawnSoldier;
        public event SelectSoldierEvent OnSelectSoldier;
        public event SetupEvent OnSetup;

        public void OnSelectSoldierRaise(string key)
        {
            OnSelectSoldier.Invoke(key);
        }

        public void OnSpawnSoldierRaise(Vector3 position)
        {
            OnSpawnSoldier.Invoke(position);
        }

        public void Setup(List<ArmyEntry> entries)
        {
            OnSetup.Invoke(entries);
        }
    }
}
