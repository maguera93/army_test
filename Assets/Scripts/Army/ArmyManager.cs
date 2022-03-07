using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAG.Utils;
using MAG.Core;

namespace MAG.Army
{
    [Serializable]
    public class ArmyEntry
    {
        public GameObject soldierPrefab;
        public int maxSoldiers;
    }

    public class ArmyManager : MonoBehaviour
    {
        [SerializeField]
        private List<ArmyEntry> entries;

        private int selectedPool;
        private Dictionary<int, ObjectPool> poolDinctionary;


        // Start is called before the first frame update
        void Start()
        {
            ArmySetup();
            GameManager.Instance.onSpawnSoldier += SpawnSoldier;
        }

        private void ArmySetup()
        {
            poolDinctionary = new Dictionary<int, ObjectPool>();

            for (int i = 0; i < entries.Count; i++)
            {
                ObjectPool soldierPool = new ObjectPool(entries[i].soldierPrefab, entries[i].maxSoldiers, transform);
                poolDinctionary.Add(i, soldierPool);
            }
        }

        public void SelectSoldier(int key)
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
