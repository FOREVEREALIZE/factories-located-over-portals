using System;
using ScriptableObjects;
using UnityEngine;

namespace GridSystem
{
    public class BuildingGrid
    {
        public BuildingScriptableObjetct[][] Buildings;

        public void SetBuildingSlot(Vector2Int position, BuildingScriptableObjetct building)
        {
            if (Buildings.Length < position.x)
            {
                Array.Resize(ref Buildings, position.x);
            }
            
            if (Buildings[position.x].Length < position.y)
            {
                Array.Resize(ref Buildings[position.x], position.y);
            }

            Buildings[position.x][position.y] = building;
        }
    }
}