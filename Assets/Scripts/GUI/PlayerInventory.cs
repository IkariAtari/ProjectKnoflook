using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToBeNamed.Inventories;
using ToBeNamed.Items;

/// <summary>
/// Will handle the player's own inventory and armor and equipment slots and GUI
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    public int InventorySize = 0;

    #region GUI stuff
    [SerializeField]
    private GameObject ItemSlotPrefab;

    [SerializeField]
    private GameObject ItemSlotContainer;

    public List<GameObject> InventorySlots = new List<GameObject>();
    #endregion

    void Start()
    {
        for (int i = 0; i < InventorySize; i++)
        {
            GameObject slot = Instantiate(ItemSlotPrefab);
            slot.transform.SetParent(ItemSlotContainer.transform);
            slot.transform.name = "ItemSlot_" + i.ToString();

            InventorySlots.Add(slot);
        }
    }

    public void AddItem(Item item)
    {
        inventory.AddItem(item, OnItemAdd);
    }

    public void RemoveItem(Item item)
    {
        inventory.RemoveItem(item, OnItemRemove);
    }

    private void OnItemAdd(Item item)
    {
        // TODO: GUI Logic here
        Debug.Log("Player Inventory GUI should update when this message pops up!");

        // TODO: Needs optimization, now we do double the call
        if (FindAvailableSlot(item) != null)
        {
            Debug.Log("Found aviabable spot!");

            ItemSlot itemSlot = FindAvailableSlot(item);

            if(itemSlot.InventoryItem.Stack < itemSlot.InventoryItem.Item.MaxStack)
            {
                // !: Update with event?
                itemSlot.InventoryItem.Stack += 1;
                itemSlot.UpdateStack(itemSlot.InventoryItem.Stack);
            }
            else
            {
                // TODO: Extra stacks here :)
            }
        }
        else
        {
            foreach (GameObject Slot in InventorySlots)
            {
                ItemSlot itemSlot = Slot.GetComponent<ItemSlot>();

                if (itemSlot.InventoryItem.Item == null)
                {
                    itemSlot.InventoryItem.Item = item;
                    itemSlot.InventoryItem.Stack = 1;
                    itemSlot.SetIcon(item.IconSprite);

                    break;
                }
            }
        }
        
    }

    private ItemSlot FindAvailableSlot(Item item)
    {
        foreach (GameObject Slot in InventorySlots)
        {
            ItemSlot itemSlot = Slot.GetComponent<ItemSlot>();

            if (itemSlot.InventoryItem.Item != null && itemSlot.InventoryItem.Item.Name == item.Name)
            {
                // TODO: Update stack

                return itemSlot;
            }
        }

        return null;
    }

    private void OnItemRemove(Item item)
    {
        // TODO: GUI Logic here
        Debug.Log("Player Inventory GUI should update when this message pops up!");
    }

    /// <summary>
    /// This method will need to be triggered once an item has completely been removede from the inventory.
    /// It will flush all items in order so there's no gaps
    /// </summary>
    private void FlushInventory()
    {

    }

    /// <summary>
    /// Being able to sort the inventory would be nice? no?
    /// </summary>
    private void SortInventory()
    {

    }
}