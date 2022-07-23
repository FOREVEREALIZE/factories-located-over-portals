using Inventories;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Item", fileName = "ItemScriptableObject")]
    public class InventoryScriptableObject : ScriptableObject
    {
        public Slot[] Slots;
    }
}