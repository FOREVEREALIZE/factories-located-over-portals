using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Building", fileName = "BuildingScriptableObject")]
    public class BuildingScriptableObjetct : ScriptableObject
    {
        public GameObject Prefab;
        public InventoryScriptableObject Inventory;
    }
}