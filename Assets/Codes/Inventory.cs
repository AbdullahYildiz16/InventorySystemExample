using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public InventoryScr playerInventory;
    public List<GameObject> slotBtns;
    Image[] slotBtnsSprites;
    Text[] slotBtnsTexts;
    bool isDragging;
    int currentSlot;
    private void Start()
    {
        slotBtnsSprites = new Image[slotBtns.Count];
        slotBtnsTexts = new Text[slotBtns.Count];
        for (int a = 0; a< slotBtns.Count; a++)
        {
            slotBtnsSprites[a] = slotBtns[a].transform.GetChild(0).GetComponent<Image>();
            slotBtnsTexts[a] = slotBtns[a].transform.GetChild(1).GetComponent<Text>();
        }
        RefreshInventory();
        
    }
    void AddItemtoInventory(Collider other)
    {
        if (playerInventory.AddItem(other.gameObject.GetComponent<Item>().item))
        {
            other.gameObject.SetActive(false);
            RefreshInventory();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            AddItemtoInventory(other);
            
                        
        }
        else if (other.gameObject.CompareTag("canned1"))
        {
            AddItemtoInventory(other);
        }
        else if (other.gameObject.CompareTag("hammer"))
        {
            AddItemtoInventory(other);
        }
    }
    public void RefreshInventory()
    {
        for(int i = 0; i< playerInventory.inventorySlots.Count; i++)
        {
            
            if (playerInventory.inventorySlots[i].item != null)
            {
                slotBtnsSprites[i].sprite = playerInventory.inventorySlots[i].item.itemIcon;
                slotBtnsTexts[i].text = playerInventory.inventorySlots[i].itemCount.ToString();
            }
            
            
        }
    }
    public void OnSlotClicked()
    {
        GameObject currentObject = EventSystem.current.currentSelectedGameObject;
        if (!isDragging)
        {
            if (playerInventory.inventorySlots[slotBtns.IndexOf(currentObject)].itemCount != 0)
            {
                isDragging = true;
                currentSlot = slotBtns.IndexOf(currentObject);
                Debug.Log("Slot First Clicked!" + currentSlot);
            }
            
        }
        else
        {
            slotBtns[currentSlot].transform.GetChild(0).GetComponent<Image>().sprite = currentObject.transform.GetChild(0).GetComponent<Image>().sprite;
            slotBtns[currentSlot].transform.GetChild(1).GetComponent<Text>().text = currentObject.transform.GetChild(1).GetComponent<Text>().text;
            playerInventory.ChangeSlotIndex(currentSlot, slotBtns.IndexOf(currentObject));
            RefreshInventory();
            Debug.Log("Slot Second Clicked!" + slotBtns.IndexOf(currentObject));
            isDragging = false;
        }
    }

    
    
}
