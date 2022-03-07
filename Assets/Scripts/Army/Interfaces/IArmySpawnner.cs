using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MAG.Army.Spawnner
{
    public interface IArmySpawnner
    {
        event SpawnSoldierEvent OnClick;
    }
}
