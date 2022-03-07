using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MAG.Core
{
    public delegate void OnSpawnSoldier(Vector3 position);

    public class GameManager : MonoBehaviour
    {

        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }

                return _instance;
            }
        }

        public OnSpawnSoldier onSpawnSoldier;
        public void SpawnSoldier(Vector3 position)
        {
            onSpawnSoldier.Invoke(position);
        }
    }
}