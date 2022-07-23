using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Item", fileName = "ItemScriptableObject")]
    public class ItemScriptableObject : ScriptableObject
    {
        public Texture texture;
        public int maxStackSize;
        public string id;
    }
}