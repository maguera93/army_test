using System.Collections.Generic;
using UnityEngine;

namespace MAG.Utils
{
    public class ObjectPool
    {
        private readonly Queue<GameObject> pool;

        public ObjectPool(GameObject prefab, int poolSize, Transform container)
        {
            pool = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject go = MonoBehaviour.Instantiate(prefab, container);
                pool.Enqueue(go);
                go.SetActive(false);
            }
        }

        public void SpawnObject(Vector3 position, Quaternion rotation)
        {
            if (pool.Count == 0)
                return;

            GameObject go = pool.Dequeue();
            go.SetActive(true);
            go.transform.position = position;
            go.transform.rotation = rotation;

            // For this project this has no use, because I'll never reuse a spawned object
            //pool.Enqueue(go);

            //return go;
        }

        public void SpawnObject(Vector3 position)
        {
            SpawnObject(position, Quaternion.identity);
        }
    }
}