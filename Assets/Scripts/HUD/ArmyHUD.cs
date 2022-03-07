using System.Collections;
using System.Collections.Generic;
using MAG.Core;
using UnityEngine;
using UnityEngine.UI;

namespace MAG.Army.HUD
{
    public class ArmyHUD : MonoBehaviour, IArmyHUD
    {
        public event SelectSoldierEvent OnSelectSoldier;
        private delegate void RemoveSoldier(string key);
        private event RemoveSoldier OnRemoveSodlier;


        [SerializeField]
        private GameObject buttonPrefab;
        [SerializeField]
        private Transform container;
        private string currentKey;

        public void SelectSoldier(string key)
        {
            OnSelectSoldier.Invoke(key);
            currentKey = key;
        }

        public void Setup(List<ArmyEntry> entries)
        {
            for (int i = 0; i < entries.Count; i ++)
            {
                GameObject button = Instantiate(buttonPrefab, container);
                if (i == 0)
                {
                    currentKey = entries[0].data.key;
                }

                SoldierButton soldierButton = button.GetComponent<SoldierButton>();
                OnRemoveSodlier += soldierButton.SpawnSoldier;
                soldierButton.Setup(entries[i], this);
            }
        }

        public void SpawnSoldier(Vector3 position)
        {
            OnRemoveSodlier(currentKey);
        }
    }
}
