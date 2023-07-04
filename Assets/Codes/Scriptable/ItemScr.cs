using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable/Item")]
public class ItemScr : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public bool canStackable;
    public Sprite itemIcon;
    public GameObject itemPrefab;

}
