using UnityEngine;
using UnityEngine.EventSystems;

namespace MAG.Army.Spawnner
{
    public class ArmySpawnner : MonoBehaviour, IArmySpawnner
    {
        public event SpawnSoldierEvent OnClick;

        [SerializeField]
        private LayerMask groundLayer;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
            {
                LaunchRaycast(Input.mousePosition);
            }
        }


        private void LaunchRaycast(Vector2 point)
        {
            Ray ray = Camera.main.ScreenPointToRay(point);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                OnClick?.Invoke(hit.point);
            }
        }
    }
}
