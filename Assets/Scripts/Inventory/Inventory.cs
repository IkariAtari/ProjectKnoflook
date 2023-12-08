using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToBeNamed.Items;

namespace ToBeNamed.Inventories
{
    [System.Serializable]
    public class Inventory
    {
        public delegate void ItemAddCallback(Item item);
        public delegate void ItemRemoveCallback(Item item);

        public List<InventoryItem> Items;

        /*public List<InventoryItem> Items
         {
            get { return Items; }
         }*/

        public Inventory()
        {
            Items = new List<InventoryItem>();
        }

        public void AddItem(Item item, ItemAddCallback callback)
        {
            // TODO: Check if the item already exists in the inventory

            //if(Items.Exists(item))
            //{

            //}

            // TODO: Check if we can still add a item to the stack
            // TODO: Otherwise we just add the item

            callback.Invoke(item);
        }

        public void RemoveItem(Item item, ItemRemoveCallback callback)
        {
            callback.Invoke(item);
        }

        /// <summary>
        /// Gets an item from the inventory and removes a stack item
        /// </summary>
        /// <param name="ItemName"></param>
        public Item GetItemByName(string ItemName)
        {
            for(int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Item.Name == ItemName)
                {
                    return Items[i].Item;
                }
            }

            return null;
        }
    }
}