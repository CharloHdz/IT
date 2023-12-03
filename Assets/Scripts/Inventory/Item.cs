using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public int str;
    public int hlt;
    public int arm;
    public int spd;
    public int dmg;
    public ItemType itemType;

    public enum ItemType
    {
        Potion,
        Helm,
        Chest,
        Boots
        
    }

    
}
