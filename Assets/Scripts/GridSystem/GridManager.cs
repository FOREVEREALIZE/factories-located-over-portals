using System;
using ScriptableObjects;
using UnityEngine;

namespace GridSystem
{
    public class GridManager : MonoBehaviour
    {
        public BuildingGrid Grid = new BuildingGrid();
        public Vector2Int gridSize = new Vector2Int(10, 10);
        public GameObject floor;
        public GameObject currentlyHeldBuilding;

        private void RenderDebugGrid()
        {
            for (int x = 0; x <= gridSize.x; x++)
            {
                Debug.DrawLine(gameObject.transform.position + new Vector3(x * 10, 0.1f, 0), new Vector3(x * 10, 0.1f, gridSize.y * 10), Color.green);
            }
            
            for (int y = 0; y <= gridSize.y; y++)
            {
                Debug.DrawLine(gameObject.transform.position + new Vector3(0, 0.1f, y * 10), new Vector3(gridSize.x * 10, 0.1f, y * 10), Color.green);
            }
        }
        private void SetFloor()
        {
            floor.transform.localScale = new Vector3(gridSize.x, 1, gridSize.y);
            floor.transform.localPosition = new Vector3(gridSize.x * 10f / 2, 0, gridSize.y * 10f / 2);
        }
        private void PositionCurrentlyHeldBuilding()
        {
            Vector3 worldPosition = Vector3.zero;
            Plane plane = new Plane(Vector3.up, 0);
        
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                worldPosition = ray.GetPoint(distance);
            }

            Vector2Int gridPos = Vector2Int.zero;
            gridPos.x = (int) Math.Floor(worldPosition.x / 10);
            gridPos.y = (int) Math.Floor(worldPosition.z / 10);

            currentlyHeldBuilding.transform.position = new Vector3(gridPos.x * 10 + 5, 5, gridPos.y * 10 + 5);
        }
        
        private void Update()
        {
            RenderDebugGrid();
            SetFloor();

            Camera.main.transform.position = floor.transform.position + new Vector3(0, Math.Max(gridSize.x, gridSize.y) * 10 + 10, 0);

            PositionCurrentlyHeldBuilding();
        }

        public bool CanBeBuilt(BuildingScriptableObjetct building, Vector2Int pos)
        {
            if (Grid.Buildings[pos.x][pos.y] != null) return false;
            
            // TODO: Add miner logic
            
            return true;
        }
        
        public void Build(BuildingScriptableObjetct building, Vector2Int pos)
        {
            if (!CanBeBuilt(building, pos)) return;

            Grid.SetBuildingSlot(pos, building);
        }
    }
}