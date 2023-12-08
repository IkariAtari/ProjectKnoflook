using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToBeNamed.Items;

namespace ToBeNamed.Inventories
{
    [System.Serializable]
    public class InventoryItem
    {
        public Item Item;
        public int Stack;
    }
}