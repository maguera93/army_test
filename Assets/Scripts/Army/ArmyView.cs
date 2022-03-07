using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAG.Utils;
using MAG.Core;

namespace MAG.Army.View
{
    public class ArmyView : MonoBehaviour, IArmyView
    {
        private string selectedPool;
        private Dictionary<string, ObjectPool> poolDinctionary;

        public void ArmySetup(List<ArmyEntry> entries)
        {
            poolDinctionary = new Dictionary<string, ObjectPool>();
            SoldierData data;

            for (int i = 0; i < entries.Count; i++)
            {
                data = entries[i].data;
                ObjectPool soldierPool = new ObjectPool(data.prefab, entries[i].maxSoldiers, transform);
                poolDinctionary.Add(data.key, soldierPool);
            }

            selectedPool = entries[0].data.key;
        }

        public void SelectSoldier(string key)
        {
            selectedPool = key;
        }

        public void SpawnSoldier(Vector3 position)
        {
            ObjectPool p;

            if (poolDinctionary.TryGetValue(selectedPool, out p))
            {
                p.SpawnObject(position);
            }
        }
    }
}
