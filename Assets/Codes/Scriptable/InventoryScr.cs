using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable/Inventory")]
public class InventoryScr : ScriptableObject
{
    public List<Slot> inventorySlots = new List<Slot>();
    int stackLimit = 3;
    public bool AddItem(ItemScr item)
    {
        foreach (Slot slot in inventorySlots)
        {
            if (slot.item == item)
            {
                if (slot.item.canStackable)
                {
                    if (slot.itemCount < stackLimit)
                    {
                        slot.itemCount++;
                        if (slot.itemCount >= stackLimit)
                        {
                            slot.isFull = true;
                        }
                        return true;
                    }                 
                }
            }
            else if (slot.itemCount == 0)
            {
                slot.AddItemtoSlot(item);
                return true;
            }
            
        }
        return false;
    }
    public void ChangeSlotIndex(int currentIndex, int newIndex)
    {
        ItemScr currentItem = inventorySlots[currentIndex].item;
        int currentItemCount = inventorySlots[currentIndex].itemCount;
        bool currentIsFull = inventorySlots[currentIndex].isFull;

        ItemScr newItem = inventorySlots[newIndex].item;
        int newItemCount = inventorySlots[newIndex].itemCount;
        bool newIsFull = inventorySlots[newIndex].isFull;

        inventorySlots[currentIndex].item = newItem;
        inventorySlots[currentIndex].itemCount = newItemCount;
        inventorySlots[currentIndex].isFull = newIsFull;

        inventorySlots[newIndex].item = currentItem;
        inventorySlots[newIndex].itemCount = currentItemCount;
        inventorySlots[newIndex].isFull = currentIsFull;


    }
}
[System.Serializable]
public class Slot
{
    public int itemCount;
    public bool isFull;
    public ItemScr item;

    public void AddItemtoSlot(ItemScr item) {
        this.item = item;

        if (item.canStackable == false)
        {
            isFull = true;
        }
        itemCount++;
    }

}
